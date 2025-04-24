using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Infrastructures.data.Entities;

namespace StarColonies.Web.Pages;

public class ProfileModel : PageModel
{
    private readonly UserManager<StarColoniesUser> _userManager;
    
    public StarColoniesUser? UserConnected { get; set; }
    
    public string BirthDateFormatted { get; set; } 
    
    public ProfileModel(UserManager<StarColoniesUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        UserConnected = await _userManager.GetUserAsync(User);
        if (UserConnected != null) BirthDateFormatted = UserConnected.BirthDate.ToString("yyyy-MM-dd");

        return Page();
    }
    
    public InputModel Input { get; set; }
    
    public class InputModel
        {
            
            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date de naissance")]
            public DateOnly BirthDate { get; set; }

        }
}

