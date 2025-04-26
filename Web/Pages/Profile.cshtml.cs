using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.Entities;

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
        Console.WriteLine($"IsAuthenticated: {User.Identity.IsAuthenticated}");
        Console.WriteLine($"Name: {User.Identity.Name}");
        Console.WriteLine($"Claims:");
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($" - {claim.Type}: {claim.Value}");
        }
        UserConnected = await _userManager.GetUserAsync(User);
        if (UserConnected != null) BirthDateFormatted = UserConnected.BirthDate.ToString("yyyy-MM-dd");

        return Page();
    }
    
    [BindProperty]
    public InputPersonalModel InputPersonal { get; set; }
    
    public InputColonModel InputColon { get; set; }
    
    public InputAvatarModel InputAvatar { get; set; }
    
        public class InputPersonalModel
        {
            
            [Required]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }
           
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date de naissance")]
            public DateOnly BirthDate { get; set; }
            
        }

        public class InputAvatarModel 
        {
            [Display(Name = "Photo de profil")]
            [DataType(DataType.ImageUrl)]
            public IFormFile? Avatar { get; set; }
        }

        public class InputColonModel : IValidatableObject
        {
            [Required]
            [Display(Name = "Profession")]
            public string Profession { get; set; } = string.Empty;

            [Range(0, 7)]
            [Display(Name = "Force")]
            public int Force { get; set; }

            [Range(0, 7)]
            [Display(Name = "Endurance")]
            public int Endurance { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Force + Endurance != 7)
                {
                    yield return new ValidationResult(
                        "La somme de la Force et de l'Endurance doit être égale à 7.",
                        new[] { nameof(Force), nameof(Endurance) });
                }
            }
        }
}

