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
    public Team SelectionedTeam{ get; set; }

    public TeamsModel(IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository, ITeamRepository teamRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _colonRepository = colonRepository;
        _teamRepository = teamRepository;
    }

    public async void OnGetAsync()
    {
        Teams = new List<Team>(); // repo
        SelectionedTeam = new Team()
        {
            Name = "Equipe test",
            ColonsTeam = new List<Colon>
            {
                new() { Name = "Maxime", Force = 5, Stamina = 2, JobName = JobName.Soldat },
                new() { Name = "Romain", Force = 5, Stamina = 2, JobName = JobName.Soldat },
                new() { Name = "Hendrikx", Force = 7, Stamina = 0, JobName = JobName.Scientifique },
                new() { Name = "Flo", Force = 5, Stamina = 2, JobName = JobName.Ingenieur }
            },
        };

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