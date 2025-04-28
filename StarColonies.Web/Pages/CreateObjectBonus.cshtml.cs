using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class CreateObjectBonus : PageModel
{
    private readonly IUserRepository _userRepository;
    private readonly IBonusObjectRepository _bonusObjectRepository;
    public User? UserConnected { get; set; }
    
    [BindProperty]
    public BonusObject BonusObject { get; set; } = new();

    public CreateObjectBonus(IUserRepository userRepository, IBonusObjectRepository bonusObjectRepository)
    {
        _userRepository = userRepository;
        _bonusObjectRepository = bonusObjectRepository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        UserConnected = await _userRepository.GetUserConnectedAsync(User);
        
        
        if (UserConnected == null || UserConnected.IsAdmin == false)
        {
            return Redirect("/Error");
        }
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        
        if (BonusObject.Price <= 0 || BonusObject.BonusForce <0|| BonusObject.BonusLevel <0|| BonusObject.BonusStamina <0)
        {
            return Page();
        }
        int sum = BonusObject.BonusForce + BonusObject.BonusLevel + BonusObject.BonusStamina;

        if (sum <= 0)
        {
            return Page();
        }
        
        try
        {
            await _bonusObjectRepository.AddBonusObjectAsync(BonusObject);
            return RedirectToPage("/TableBonusObject");
        }
        catch (Exception ex)
        {
            return Page();
        }
    }
}