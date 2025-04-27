using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class TeamsModel : PageModel
{
    private readonly IColonRepository _colonRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ITeamRepository _teamRepository;
    [BindProperty]
    public required InputFormModel InputModel { get; set; } = new ();
    public IList<string> TeamsNames { get; set; } = new List<string>();
    public IList<Team> Teams { get; set; }

    public TeamsModel(IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository, ITeamRepository teamRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _colonRepository = colonRepository;
        _teamRepository = teamRepository;
    }

    public async void OnGetAsync()
    {
        Teams = await _teamRepository.GetAllTeamsAsync();

        foreach (var team in Teams)
        {
            TeamsNames.Add(team.Name);
        }
    }

    public class InputFormModel
    {
        public string TeamName { get; set; }
    }
}