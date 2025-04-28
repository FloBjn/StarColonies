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
    public Statistics Statistics { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IMissionHistoryRepository missionHistoryRepository,ITeamRepository teamRepository)
    {
        _logger = logger;
        _missionHistoryRepository = missionHistoryRepository;
        _teamRepository = teamRepository;
        Statistics = new Statistics();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Statistics.MissionHistories = await _missionHistoryRepository.GetMissionsHistoryAsync();
        Statistics.Teams = await _teamRepository.GetAllTeamsAsync();
        return Page();
    }
}