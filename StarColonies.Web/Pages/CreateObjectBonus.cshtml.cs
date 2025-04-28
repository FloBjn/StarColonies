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
        
        //TODO Vérifier si c'est admin
        if (UserConnected == null)
        {
            return Redirect("/Error");
        }
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _bonusObjectRepository.AddBonusObjectAsync(BonusObject);
            return RedirectToPage("/TableObjectBonus");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Une erreur est survenue: {ex.Message}");
            return Page();
        }
    }
}