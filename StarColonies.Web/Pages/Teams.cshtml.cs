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
    private readonly IUserRepository _userService;

    [BindProperty]
    public required InputFormModel InputModel { get; set; } = new ();
    public IList<Team> Teams { get; set; }
    public Team? SelectionedTeam{ get; set; }
    [BindProperty]
    public string RedirectAction { get; set; } = string.Empty;

    public TeamsModel(IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository, ITeamRepository teamRepository, IUserRepository userService)
    {
        _webHostEnvironment = webHostEnvironment;
        _colonRepository = colonRepository;
        _teamRepository = teamRepository;
        _userService = userService;
    }

    public async Task OnGetAsync()
    {
        var user = await _userService.GetUserConnectedAsync(User);
        Teams = await _teamRepository.GetAllTeamsAsync();// repo
        Teams = Teams.Where(t => t.ColonsTeam.Any(c => c.ColonId == user.ColonId))
            .ToList();
        // Console.WriteLine($"Teams: {Teams[0].ColonsTeam.Count}");
        // Console.WriteLine($"Teams: {Teams[1].ColonsTeam.Count}");
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
        var team = await _teamRepository.GetByIdAsync(InputModel.TeamId);
        if (team != null)
        {
            Console.WriteLine("teamfind : " + team.Name);
            SelectionedTeam = team;
            InputModel.TeamId = team.TeamId;
            Console.WriteLine("teamfind : " + SelectionedTeam.TeamId);
        }
        Console.WriteLine($"action: {RedirectAction}");
        switch (RedirectAction)
        {
            case "Create":
                HttpContext.Session.SetString("SelectedId", "");
                return RedirectToPage("/CreateTeam");
            case "Modify":
                // Console.WriteLine($"action: {SelectionedTeam.TeamId}");
                /*Console.WriteLine($"action: {InputModel.TeamId}");
                HttpContext.Session.SetString("SelectedId", InputModel.TeamId);*/
                return RedirectToPage("/UpdateTeam");
            case "Get":
                HttpContext.Session.SetString("SelectedId", SelectionedTeam.TeamId);
                var user = await _userService.GetUserConnectedAsync(User);
                Teams = await _teamRepository.GetAllTeamsAsync();// repo
                Teams = Teams.Where(t => t.ColonsTeam.Any(c => c.ColonId == user.ColonId)).ToList();
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