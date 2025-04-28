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
    private readonly IMissionHistoryRepository _missionHistoryRepository;
    public Team? Team { get; set; }
    public Colon? UserColon { get; set; }
    public String TeamId { get; set; }
    
    public TableMission(ITeamRepository teamRepository, IMissionRepository missionRepository,IUserRepository userRepository,IColonRepository colonRepository,IMissionHistoryRepository missionHistoryRepository)
    {
        _teamRepository = teamRepository;
        _missionRepository = missionRepository;
        _userRepository = userRepository;
        _colonRepository = colonRepository;
        _missionHistoryRepository = missionHistoryRepository;
        
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
        if (Team.LevelMaxAuthorized!=0 && Team.LevelMaxAuthorized < mission.Level && Team.LevelMaxAuthorized!=1)
        {
            TempData["Error"] = "Votre equipe doit d'abord surmonte une mission plus simple.";
            return RedirectToPage(new { TeamId });
        }
        
        
        MissionHistory missionHistory = new MissionHistory
        {
            MissionId = mission.MissionId,
            Mission = mission,
            TeamId = Team.TeamId,
            Team = Team
        };
        
        //Vérifie si l'équipe a réussi la mission
        if (!mission.IsChallengesOvercomed(Team) || !mission.IsTeamAlive(Team))
        {
            Team.LevelMaxAuthorized = mission.Level;
            await _teamRepository.UpdateTeamMaxLvlMissionAsync(Team);
            missionHistory.IsSuccess = false;
            
            await _missionHistoryRepository.AddMissionHistoryAsync(missionHistory);
            if (!mission.IsTeamAlive(Team))
            {
                TempData["Error"] = "Votre equipe a peri durant la mission";
            }
            else
            {
                TempData["Error"] = "L'equipe n'a pas surmonté les défis.";
            }
            return RedirectToPage(new { TeamId });
        }
        
        
        UserColon.AddResource(mission.GetReward());
        await _colonRepository.UpdateColonNumberResource(UserColon);

        foreach (var colon in Team.ColonsTeam )
        {
            colon.LevelUp();
            await _colonRepository.UpdateColonPerfAsync(colon);
        }

        //Enlève la restriction de lvl max de la mission que l'équipe peut faire
        Team.LevelMaxAuthorized = 0;
        await _teamRepository.UpdateTeamMaxLvlMissionAsync(Team);
        
        //Rajoute dans l'historique le résultat de la mission
        missionHistory.IsSuccess = true;
        await _missionHistoryRepository.AddMissionHistoryAsync(missionHistory);
        
        //Supprime tout les objets de la team (les objets ne sont actif que pour la prochaine mission que l'équipe fait)
        Team.TeamBonusObjects = new List<BonusObject>();
        await _teamRepository.DeleteTeamObjectsAsync(Team);
        
        TempData["Success"] = $"Mission {mission.Name} terminée avec succès!";
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