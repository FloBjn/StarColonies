using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;
using StarColonies.Domains;
namespace StarColonies.Web.Pages;

public class TableMission : PageModel
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMissionRepository _missionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IColonRepository _colonRepository;
    public Team? Team { get; set; }
    public Colon? UserColon { get; set; }
    public String TeamId { get; set; }
    
    public TableMission(ITeamRepository teamRepository, IMissionRepository missionRepository,IUserRepository userRepository,IColonRepository colonRepository)
    {
        _teamRepository = teamRepository;
        _missionRepository = missionRepository;
        _userRepository = userRepository;
        _colonRepository = colonRepository;
        
    }
    public async Task<List<Mission>> GetAllMissions()
    {
        return await _missionRepository.GetAllAsync();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        
        TeamId = Request.Query["TeamId"];
        await SetTeam();
        if (Team == null)
        {
            return Redirect("/Error"); 
        }
        await SetConnectedUser();
    
        if (UserColon == null)
        {
            return Redirect("/Error");
        }
        
        return Page();
    }
    private async Task SetTeam()
    {
        Team = await _teamRepository.GetByIdAsync(TeamId);
    }
    public async Task<IActionResult> OnPostAsync(string missionId)
    {
        TeamId = Request.Query["TeamId"];
        await SetTeam();
        if (Team == null)
        {
            return Redirect("/Error"); 
        }
        await SetConnectedUser();
    
        if (UserColon == null)
        {
            return Redirect("/Error");
        }

        var mission = await _missionRepository.GetByIdAsync(missionId);
        if (mission == null)
        {
            TempData["Error"] = "Cette mission n'existe pas.";
            return RedirectToPage(new { TeamId });
        }
        //TODO LA LOGIQUE DE CECI
        if (!(mission.Level < Team.LevelMaxAuthorized))
        {
            TempData["Error"] = "Votre equipe doit d'abord surmonte une mission plus simple.";
            return RedirectToPage(new { TeamId });
        }
        if (mission.ChallengesOvercome(Team))
        {
            Team.LevelMaxAuthorized = mission.Level;
            await _teamRepository.UpdateTeamMaxLvlMissionAsync(Team);
            TempData["Error"] = "Vous n'avez pas su surmontés les defis";
            return RedirectToPage(new { TeamId });
        }

        if (mission.ChallengesOvercome(Team))
        {
            Team.LevelMaxAuthorized = mission.Level;
            await _teamRepository.UpdateTeamMaxLvlMissionAsync(Team);
            TempData["Error"] = "Votre equipe a peri durant la mission";
            return RedirectToPage(new { TeamId });
        }
        UserColon.AddResource(mission.GetReward());
        await _colonRepository.UpdateColonNumberResource(UserColon);

        foreach (var colon in Team.ColonsTeam )
        {
            colon.LevelUp();
            await _colonRepository.UpdateColonPerfAsync(colon);
        }

        Team.LevelMaxAuthorized = 0;
        await _teamRepository.UpdateTeamMaxLvlMissionAsync(Team);
        //TODO SUPPRIMER TOUS LES OBJECT DE L'EQUIPE
        
        TempData["Success"] = $"Mission {mission.Name} lancée avec succès!";
        return RedirectToPage(new { TeamId });
    }
    private async Task SetConnectedUser()
    {
        var userConnected = await _userRepository.GetUserConnectedAsync(User);
        if (userConnected != null)
        {
            UserColon = await _colonRepository.GetColonByIdAsync(userConnected.ColonId);
        }
    }
}