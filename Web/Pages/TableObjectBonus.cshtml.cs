using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class TableObjectBonus : PageModel
{
    private readonly IUserRepository _userRepository;
    private readonly IBonusObjectRepository _bonusObjectRepository;
    public User? UserConnected { get; set; }
    public TableObjectBonus(IUserRepository userRepository,IBonusObjectRepository objectRepository)
    {
        _userRepository = userRepository;
        _bonusObjectRepository = objectRepository;
    } 
    public async Task<IActionResult> OnGetAsync()
    {
        UserConnected = await _userRepository.GetUserConnectedAsync(User);
        //TODO verifier que c'est un admin 
        if (UserConnected == null)
        {
            return Redirect("/Error"); 
        }
        return Page();
    }
    public async Task<List<BonusObject>> GetAllBonusObejcts()
    {
        return await _bonusObjectRepository.GetAllBonusObjectsAsync();
    }
}