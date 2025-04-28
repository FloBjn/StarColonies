using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class Stats : PageModel
{
    private IMissionRepository _missionRepository;
    private IMissionHistoryRepository _missionHistoryRepository;
    [BindProperty]
    public required IList<Mission> MissionsList { get; set; }
    [BindProperty]
    public List<string> Labels { get; set; } = ["Victoire", "Défaite"];

    [BindProperty] public IList<List<int>> DataSets { get; set; } = new List<List<int>>();/*[[20,80],[30,70],[40,60],[50,50],[60,40],[70,30]];*/

    public Stats(IMissionRepository missionRepository, IMissionHistoryRepository missionHistoryRepository)
    {
        _missionRepository = missionRepository;
        _missionHistoryRepository = missionHistoryRepository;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        MissionsList = await _missionRepository.GetAllAsync();

        var stats = new Statistics();
        stats.MissionHistories = await _missionHistoryRepository.GetMissionsHistoryAsync();
        foreach (var mission in MissionsList)
        {
            if (mission != null)
            {
                var win = (int?)stats.GetWinningpercentageOfMissions(mission);
                if (win != null)
                {
                    var lose = (int)(100 - win);
                    DataSets.Add([(int)win, lose]);
                }
                else
                {
                    DataSets.Add([0, 0]);
                }
            }
        }
        
        return Page();
    }
}