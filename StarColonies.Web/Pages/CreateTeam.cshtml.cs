using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages;

[Authorize]
    public class CreateTeam : PageModel
    {
        // Form input
        [BindProperty]
        public InputTeamInfosModel InputTeamInfosModel { get; set; }

        [BindProperty]
        public List<ColonInputModel> ColonModelList { get; set; } = new();

        public Team ModifyingTeam { get; set; }
        public ColonInputModel OptionalColon { get; set; }

        private readonly IUserRepository _userService;
        private readonly ITeamRepository _teamService;

        public CreateTeam(IUserRepository userService, ITeamRepository teamService)
        {
            _userService = userService;
            _teamService = teamService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Récupère l'utilisateur connecté
            var user = await _userService.GetUserConnectedAsync(User);

            // Préremplir le premier colon avec ses infos
            ColonModelList = new List<ColonInputModel>();
            ColonModelList.Add(new ColonInputModel
            {
                Name = user.Name,
                ProfessionId = JobNameMapper.ToInt(user.UserColon.JobName), // Exemple, profession par défaut
                Force = user.UserColon.Force,
                Endurance = user.UserColon.Stamina
            });

            // Complète avec des slots vides pour arriver à 5
            while (ColonModelList.Count < 5)
            {
                ColonModelList.Add(new ColonInputModel());
            }

            return Page();
        }
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Validation supplémentaire : au moins 4 colons remplis
            var filledColons = ColonModelList
                .Where(c => !string.IsNullOrWhiteSpace(c.Name))
                .ToList();

            if (filledColons.Count < 4)
            {
                ModelState.AddModelError(string.Empty, "Vous devez remplir au moins 4 colons.");
                return Page();
            }

            if (filledColons.Count > 5)
            {
                ModelState.AddModelError(string.Empty, "Vous ne pouvez pas créer plus de 5 colons.");
                return Page();
            }

            // Enregistre l'équipe et les colons
            var team = new Team
            {
                Name = InputTeamInfosModel.TeamName,
            };
            
            foreach (var model in filledColons)
            {
                team.ColonsTeam.Add(new Colon
                {
                    Name = model.Name,
                    Force = model.Force,
                    Stamina = model.Endurance,
                    JobName = JobNameMapper.ToJobName(model.ProfessionId)
                });
            }
            
            await _teamService.AddTeamAsync(team);

            
            ModelState.AddModelError(string.Empty, "Erreur lors de la création de l'équipe.");
            
            

            return RedirectToPage("/Teams");
        }
    }

    public class InputTeamInfosModel
    {
        [Required]
        public string TeamName { get; set; }
        [BindProperty]
        public IFormFile? Banner { get; set; }
    }

    public class ColonInputModel
    {
        public string? TeamId { get; set; }

        public int Index { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }

        [Range(0, 3)]
        public int ProfessionId { get; set; }

        [Range(0, 7)]
        public int Force { get; set; }

        [Range(0, 7)]
        public int Endurance { get; set; }
    }