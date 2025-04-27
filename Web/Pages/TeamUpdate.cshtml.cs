using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;

namespace StarColonies.Web.Pages;

public class TeamUpdate : PageModel
{
    private readonly StarColoniesContext _context;
    private readonly ITeamRepository _teamRepository;
    public bool IsCreatingTeam { get; set; } = false;
    public Team? ModifyingTeam {get; set;}

    public TeamUpdate(StarColoniesContext context, ITeamRepository teamRepository)
    {
        _context = context;
        _teamRepository = teamRepository;
        
    }
    public async void OnGetAsync(string id)
    {
        ModifyingTeam = await _teamRepository.GetByIdAsync(id);
        if (ModifyingTeam == null)
        {
            IsCreatingTeam = true;
        }
    }
}