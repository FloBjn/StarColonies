// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<StarColoniesUser> _signInManager;
        private readonly UserManager<StarColoniesUser> _userManager;
        private readonly IUserStore<StarColoniesUser> _userStore;
        private readonly IUserEmailStore<StarColoniesUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly StarColoniesContext _context;
        private readonly IUserRepository _userRepository;

        public RegisterModel(
            UserManager<StarColoniesUser> userManager,
            IUserStore<StarColoniesUser> userStore,
            SignInManager<StarColoniesUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IWebHostEnvironment webHostEnvironment,
            StarColoniesContext context,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userRepository = userRepository;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel : IValidatableObject
        {
            
            [Required]
            [Display(Name = "FirstName")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Date de naissance")]
            public DateOnly BirthDate { get; set; }
            
            #nullable enable

            [Display(Name = "Photo de profil")]
            [DataType(DataType.ImageUrl)]
            public IFormFile? Avatar { get; set; }
            #nullable disable
            
            [Required]
            [Display(Name = "Profession")]
            public int Profession { get; set; }

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


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var colon = new Colon
                {
                    Name = Input.Name,
                    JobName = JobNameMapper.ToJobName(Input.Profession),
                    Force = Input.Force,
                    Stamina = Input.Endurance,
                };
                
                var user = new User
                {
                    BirthDate = Input.BirthDate,
                    UserColon = colon,
                };
                
                // Traitement de l'image avant la création de l'utilisateur
                if (_webHostEnvironment.IsDevelopment())
                {
                    await UploadImageDev(user);
                }
                else
                {
                    await UploadImageProd(user);
                }

                // await _userRepository.AddAsync(user);
                await _context.SaveChangesAsync();

                var scUser = UserMapper.ToEntity(user);

                await _userStore.SetUserNameAsync(scUser, Input.Name, CancellationToken.None);
                await _emailStore.SetEmailAsync(scUser, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(scUser, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    
                    Console.Out.Write("scUserId : " + scUser.Id);

                    var userId = await _userManager.GetUserIdAsync(scUser);
                    Console.Out.Write("userId : " + userId);

                    var claims = new List<Claim>
                    {
                        new (ClaimTypes.NameIdentifier, userId), // Ajouter l'ID comme claim
                    };
                    await _userManager.AddClaimsAsync(scUser, claims);
                    
                    
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(scUser);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(scUser, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task UploadImageDev(User user)
        {
            if (Input.Avatar != null && Input.Avatar.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/profiles");
                Directory.CreateDirectory(uploadsFolder); // Création si dossier inexistant
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Input.Avatar.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.Avatar.CopyToAsync(fileStream);
                }

                // Affecte le chemin de l’image à l’utilisateur
                user.Avatar = "/images/profiles/" + fileName;
            }
        }
        
        private async Task UploadImageProd(User user)
        {
            if (Input.Avatar != null && Input.Avatar.Length > 0)
            {
                var fileName = Path.GetFileName(Input.Avatar.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);

                // Crée le dossier s'il n'existe pas
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.Avatar.CopyToAsync(fileStream);
                }

                // Affecte le chemin de l’image à l’utilisateur
                user.Avatar = $"/Q230243/image/{fileName}";
            }
        }

        private IUserEmailStore<StarColoniesUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<StarColoniesUser>)_userStore;
        }
    }
}
