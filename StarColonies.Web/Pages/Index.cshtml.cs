using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;
using StarColonies.Domains;
namespace StarColonies.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMissionHistoryRepository _missionHistoryRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IMissionRepository _missionRepository;

    public Statistics Statistics { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IMissionHistoryRepository missionHistoryRepository,ITeamRepository teamRepository,IMissionRepository missionRepository)
    {
        _logger = logger;
        _missionHistoryRepository = missionHistoryRepository;
        _teamRepository = teamRepository;
        _missionRepository = missionRepository;
        Statistics = new Statistics();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Statistics.MissionHistories = await _missionHistoryRepository.GetMissionsHistoryAsync();
        Statistics.Teams = await _teamRepository.GetAllTeamsAsync();
        Statistics.Missions = await _missionRepository.GetAllAsync();
        return Page();
    }
}