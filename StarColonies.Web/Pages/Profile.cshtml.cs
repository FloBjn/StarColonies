using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages;

public class ProfileModel : PageModel
{
    private readonly UserManager<StarColoniesUser> _userManager;
    private readonly IUserRepository _userRepository;
    private readonly IColonRepository _colonRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public User? UserConnected { get; set; }
    public Colon? UserColon { get; set; }
    [BindProperty]
    public string FormName { get; set; } = string.Empty;
    public string BirthDateFormatted { get; set; } = string.Empty;
    [BindProperty] 
    public required InputPersonalModel InputPersonal { get; set; } = new();
    [BindProperty]
    public required InputColonModel InputColon { get; set; } = new();
    [BindProperty]
    public required InputAvatarModel InputAvatar { get; set; } = new();
    
    public ProfileModel(UserManager<StarColoniesUser> userManager, IUserRepository userRepository,
        IWebHostEnvironment webHostEnvironment, IColonRepository colonRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;   
        _webHostEnvironment = webHostEnvironment;
        _colonRepository = colonRepository;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await SetConnectedUser();

        return Page();
    }

    private async Task SetConnectedUser()
    {
        UserConnected = await _userRepository.GetUserConnectedAsync(User);
        if (UserConnected != null)
        {
            BirthDateFormatted = UserConnected.BirthDate.ToString("yyyy-MM-dd");
            UserColon = UserConnected.UserColon;
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await SetConnectedUser();
        ModelState.Clear();
        switch (FormName)
        {
            case "PersonalForm":
                if (!TryValidateModel(InputPersonal)) return Page();
                await UpdatePersonalInfo();
                break;
            case "ColonForm":
                if (!TryValidateModel(InputColon)) return Page();
                await UpdateColonInfo();
                break;
            case "AvatarForm":
                if (!TryValidateModel(InputAvatar)) return Page();
                await UpdateAvatarInfo();
                break;
            default:
                ModelState.AddModelError(string.Empty, "Formulaire inconnu.");
                break;
        }
        
        return RedirectToPage();
    }

    private async Task UpdateAvatarInfo()
    {
        var userDb = await _userManager.GetUserAsync(User);
        if (userDb == null) return;

        if (_webHostEnvironment.IsDevelopment())
        {
            await UploadImageDev(userDb);
        }
        else
        {
            await UploadImageProd(userDb);
        }
        
        var result = await _userManager.UpdateAsync(userDb);
    }

    private async Task UpdateColonInfo()
    {
        UserColon.Force = InputColon.Force;
        UserColon.Stamina = InputColon.Endurance;
        
        await _colonRepository.UpdateColonPerfAsync(UserColon);
    } 

    private async Task UpdatePersonalInfo()
    {
        Console.WriteLine("userColon : " + UserConnected.Name);
        UserConnected.Name = InputPersonal.FirstName;
        UserConnected.BirthDate = InputPersonal.BirthDate;
        UserConnected.Email = InputPersonal.Email;
        
        await _userRepository.UpdateUserAsync(UserConnected);
        Console.WriteLine("userColon : " + UserColon.Name);
        UserConnected.UserColon.Name = InputPersonal.FirstName;
        await _colonRepository.UpdateColonNameAsync(UserConnected.UserColon);
        UserColon = UserConnected.UserColon;
    }
    
    private async Task UploadImageDev(StarColoniesUser user)
    {
        if (InputAvatar.Avatar != null && InputAvatar.Avatar.Length > 0)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/profiles");
            Directory.CreateDirectory(uploadsFolder); // Création si dossier inexistant
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(InputAvatar.Avatar.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await InputAvatar.Avatar.CopyToAsync(fileStream);
            }

            // Affecte le chemin de l’image à l’utilisateur
            user.Avatar = "/images/profiles/" + fileName;
        }
    }
    
    private async Task UploadImageProd(StarColoniesUser user)
    {
        if (InputAvatar.Avatar != null && InputAvatar.Avatar.Length > 0)
        {
            var fileName = Path.GetFileName(InputAvatar.Avatar.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);

            // Crée le dossier s'il n'existe pas
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await InputAvatar.Avatar.CopyToAsync(fileStream);
            }

            // Affecte le chemin de l’image à l’utilisateur
            user.Avatar = $"/Q230243/image/{fileName}";
        }
    }
    
        public class InputPersonalModel
        {
             [Required(ErrorMessage = "Le pseudo est requis.")]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "L'email est requis.")]
            [EmailAddress(ErrorMessage = "L'email n'est pas valide.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La date de naissance est requise.")]
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
            /*[Required]
            [Display(Name = "Profession")]
            public string Profession { get; set; } = string.Empty;*/

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

