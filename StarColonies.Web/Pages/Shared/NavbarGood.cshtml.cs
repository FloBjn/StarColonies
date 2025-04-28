using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages.Shared;

public class NavbarGoodModel : PageModel
{
    private readonly IUserRepository _userRepository;
    
    public User? UserConnected { get; set; }
    
    public NavbarGoodModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;   
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await SetConnectedUser();

        return Page();
    }
    
    private async Task SetConnectedUser()
    {
        UserConnected = await _userRepository.GetUserConnectedAsync(User);
    }
}