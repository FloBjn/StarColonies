using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Infrastructures.data.Entities;

namespace StarColonies.Web.Pages;

public class LogoutModel : PageModel
{
    private readonly SignInManager<StarColoniesUser> _signInManager;

    public LogoutModel(SignInManager<StarColoniesUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();

        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        else
        {
            return RedirectToPage("/Index");
        }
    }
    
    
    public void OnGet()
    {
        
    }
}