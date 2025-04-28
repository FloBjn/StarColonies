using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class BlackMarket : PageModel
{
    private readonly IBonusObjectRepository _bonusObjectRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IColonRepository _colonRepository;
    public Colon? UserColon { get; set; }
    public Team? Team { get; set; }
    public String TeamId { get; set; }
    public BlackMarket(IBonusObjectRepository bonusObjectRepository, IUserRepository userRepository,ITeamRepository teamRepository, IColonRepository colonRepository)
    {
        _bonusObjectRepository = bonusObjectRepository;
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _colonRepository = colonRepository;
    }
    public async Task<List<BonusObject>> GetAllBonusObjects()
    {
        return await _bonusObjectRepository.GetAllBonusObjectsAsync();
    }

    public async Task<IActionResult> OnGetAsync()
    {
        
        TeamId = Request.Query["TeamId"];
        await SetTeam();
        if (Team == null)
        {
            return Redirect("/Error"); 
        }
        await SetConnectedUser();
        
        return Page();
    }

    private async Task SetTeam()
    {
        Team = await _teamRepository.GetByIdAsync(TeamId);
    }

    private async Task SetConnectedUser()
    {
        var userConnected = await _userRepository.GetUserConnectedAsync(User);
        if (userConnected != null)
        {
            UserColon = await _colonRepository.GetColonByIdAsync(userConnected.ColonId);
        }
    }
    public async Task<IActionResult> OnPostAsync(string objetId)
    {
        TeamId = Request.Query["TeamId"];
        await SetTeam();
        if (Team == null)
        {
            return Redirect("/Error"); 
        }
        await SetConnectedUser();
    
        if (UserColon == null)
        {
            return Redirect("/Error");
        }

        var bonus = await _bonusObjectRepository.GetBonusObjectByIdAsync(objetId);
        if (bonus == null)
        {
            TempData["Error"] = "This bonus does not exist.";
            return RedirectToPage(new { TeamId });
        }

        if (UserColon.NumberResource < bonus.Price)
        {
            TempData["Error"] = "You dont have enough resources for this purchase.";
            return RedirectToPage(new { TeamId });
        }

        if (Team.TeamBonusObjects.Contains(bonus))
        {
            TempData["Error"] = "You already own this item.";
            return RedirectToPage(new { TeamId });
        }

        UserColon.SubtractResource(bonus.Price);
        await _colonRepository.UpdateColonNumberResource(UserColon);
        //TODO Ajouter Les objects a la team
        TempData["Success"] = bonus.Name+" purchase successful!";
        return RedirectToPage(new { TeamId });
    }
    
}