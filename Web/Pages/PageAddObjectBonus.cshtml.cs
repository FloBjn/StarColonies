using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class PageAddObjectBonus : PageModel
{
    private readonly IUserRepository _userRepository;
    private readonly IBonusObjectRepository _bonusObjectRepository;
    [BindProperty]
    public BonusObject BonusObject { get; set; } = new();
    public User? UserConnected { get; set; }
    public PageAddObjectBonus(IUserRepository userRepository,IBonusObjectRepository objectRepository)
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
            Console.Write("Error");
            return Page();
        }
    }
}