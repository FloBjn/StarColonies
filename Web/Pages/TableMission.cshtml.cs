using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;
using StarColonies.Domains;
namespace StarColonies.Web.Pages;

public class TableMission : PageModel
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMissionRepository _missionRepository;
    public Team? Team { get; set; }
    
    public String TeamId { get; set; }
    
    public TableMission(ITeamRepository teamRepository, IMissionRepository missionRepository)
    {
        _teamRepository = teamRepository;
        _missionRepository = missionRepository;
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

        var mission = await _missionRepository.GetByIdAsync(missionId);
        if (mission == null)
        {
            TempData["Error"] = "Cette mission n'existe pas.";
            return RedirectToPage(new { TeamId });
        }

        // Vérifier si l'équipe a le niveau requis
        if (true)
        {
            TempData["Error"] = "Votre équipe n'a pas le niveau requis pour cette mission.";
            return RedirectToPage(new { TeamId });
        }

        // TODO: Ajouter la logique pour lancer la mission
        // Par exemple, créer un combat, rediriger vers l'écran de combat, etc.

        TempData["Success"] = $"Mission {mission.Name} lancée avec succès!";
        return RedirectToPage(new { TeamId });
    }
}