using System.ComponentModel.DataAnnotations;
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
    public IList<Team> Teams { get; set; }
    public Team? SelectionedTeam{ get; set; }
    [BindProperty]
    public string RedirectAction { get; set; } = string.Empty;

    public TeamsModel(IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository, ITeamRepository teamRepository)
    {
        _webHostEnvironment = webHostEnvironment;
        _colonRepository = colonRepository;
        _teamRepository = teamRepository;
    }

    public async Task OnGetAsync()
    {
        Teams = await _teamRepository.GetAllTeamsAsync();// repo
        
        Console.WriteLine($"Teams: {Teams[0].ColonsTeam.Count}");
        Console.WriteLine($"Teams: {Teams[1].ColonsTeam.Count}");
        /*SelectionedTeam = new Team()
        {
            Name = "Equipe test",
            ColonsTeam = new List<Colon>
            {
                new() { Name = "Maxime", Force = 5, Stamina = 2, JobName = JobName.Soldat },
                new() { Name = "Romain", Force = 5, Stamina = 2, JobName = JobName.Soldat },
                new() { Name = "Hendrikx", Force = 7, Stamina = 0, JobName = JobName.Scientifique },
                new() { Name = "Flo", Force = 5, Stamina = 2, JobName = JobName.Ingenieur }
            },
        };*/
    }

    public async Task<IActionResult> OnPostAsync()
    {
        
        
        
        Console.WriteLine($"action: {RedirectAction}");
        switch (RedirectAction)
        {
            case "Create":
                HttpContext.Session.SetString("SelectedId", "");
                return RedirectToPage("/CreateTeam");
            case "Modify":
                HttpContext.Session.SetString("SelectedId", SelectionedTeam.TeamId);
                return RedirectToPage("/UpdateTeam");
            case "Get":
                Teams = await _teamRepository.GetAllTeamsAsync();// repo
                if (ModelState.IsValid)
                {
                    var team = await _teamRepository.GetByIdAsync(InputModel.TeamId);
                    if (team != null)
                    {
                        Console.WriteLine("teamfind : " + team.Name);
                        SelectionedTeam = team;
                    }
                }
                break;
            default:return Page();
        }

        return Page();
    }

    public class InputFormModel
    {
        [Required]
        [Display(Name = "TeamId")]
        public string TeamId { get; set; }
    }
}