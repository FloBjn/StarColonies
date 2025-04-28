using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class Stats : PageModel
{
    private IMissionRepository _missionRepository;
    [BindProperty]
    public required IList<Mission> MissionsList { get; set; }
    [BindProperty]
    public List<string> Labels { get; set; } = ["Victoire", "Défaite"];
    [BindProperty]
    public IList<List<int>> DataSets { get; set; } = [[20,80],[30,70],[40,60],[50,50],[60,40],[70,30]];

    public Stats(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        MissionsList = await _missionRepository.GetAllAsync();

        var stats = new Statistics();
        foreach (var mission in MissionsList)
        {
            // var win = (int)stats.GetWinningpercentageOfMissions(mission);
            // var lose = (int)(100 - win);
            // DataSets.Add([win, lose]);
        }
        
        return Page();
    }
}