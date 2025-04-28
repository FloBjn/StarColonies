using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class DashboardModel : PageModel
{
    private readonly IColonRepository _colonRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userService;

    [BindProperty]
    public required TeamsModel.InputFormModel InputModel { get; set; } = new ();
    public IList<Team> Teams { get; set; }
    public Team? SelectionedTeam{ get; set; }
    [BindProperty]
    public string RedirectAction { get; set; } = string.Empty;

    public DashboardModel(IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository, ITeamRepository teamRepository, IUserRepository userService)
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
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        Console.WriteLine($"action: {RedirectAction}");
        switch (RedirectAction)
        {
            case "Get":
                SelectionedTeam = await _teamRepository.GetByIdAsync(InputModel.TeamId);
                if (SelectionedTeam == null) return RedirectToPage("/Dashboard");
                InputModel.TeamId = SelectionedTeam.TeamId;
                Console.WriteLine("teamfind : " + SelectionedTeam.TeamId);
                
                HttpContext.Session.SetString("SelectedId", SelectionedTeam.TeamId);
                var user = await _userService.GetUserConnectedAsync(User);
                Teams = await _teamRepository.GetAllTeamsAsync();// repo
                Teams = Teams.Where(t => t.ColonsTeam.Any(c => c.ColonId == user.ColonId)).ToList();
                break;
            default:return Page();
        }

        return Page();
    }
}