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
    public InputTeamInfosModel InputTeamInfos { get; set; }

    [BindProperty] 
    public List<ColonInputModel> ColonModelList { get; set; } = new List<ColonInputModel>
    {
        new ColonInputModel(),
        new ColonInputModel(),
        new ColonInputModel(),
        new ColonInputModel()
    };

    public Team ModifyingTeam { get; set; }
    public ColonInputModel OptionalColon { get; set; } = new ColonInputModel();

    private readonly IUserRepository _userService;
    private readonly ITeamRepository _teamService;
    private readonly IColonRepository _colonService;
    private readonly StarColoniesContext _context;

    public CreateTeam(IUserRepository userService, ITeamRepository teamService, StarColoniesContext starColoniesContext, IColonRepository colonRepository)
    {
        _userService = userService;
        _teamService = teamService;
        _context = starColoniesContext;
        _colonService = colonRepository;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        // Récupère l'utilisateur connecté
        UserConnected = await _userService.GetUserConnectedAsync(User);

        // Préremplir le premier colon avec ses infos
        ColonModelList = new List<ColonInputModel>();
        ColonModelList.Add(new ColonInputModel
        {
            Name = UserConnected.Name,
            ProfessionId = JobNameMapper.ToInt(UserConnected.UserColon.JobName), // Exemple, profession par défaut
            Force = UserConnected.UserColon.Force,
            Endurance = UserConnected.UserColon.Stamina,
            ColonId = UserConnected.UserColon.ColonId
        });

        // Complète avec des slots vides pour arriver à 5
        while (ColonModelList.Count < 4)
        {
            Console.WriteLine(ColonModelList.Count);
            ColonModelList.Add(new ColonInputModel());
        }

        return Page();
    }

    public User? UserConnected { get; set; }


    public async Task<IActionResult> OnPostAsync()
    {
        // UserConnected = await _userService.GetUserConnectedNotTrackedAsync(User);
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Validation : vérifier que 4 colons du for sont remplis
        var filledColons = ColonModelList
            .Where(c => !string.IsNullOrWhiteSpace(c.Name))
            .ToList();

        if (filledColons.Count != 4)
        {
            ModelState.AddModelError(string.Empty, "Vous devez remplir exactement 4 colons.");
            return Page();
        }

        // Enregistre l'équipe et les colons
        var team = new Team
        {
            Name = InputTeamInfos.TeamName,
        };

        foreach (var model in filledColons)
        {
            if (model.ColonId != null && model.ColonId == (await _userService.GetUserConnectedNotTrackedAsync(User)).ColonId)
            {
                var colon = await _colonService.GetColonByIdNotTrackedAsync(model.ColonId);
                // Vérifier si l'entité est déjà suivie par le DbContext
                colon.Name = model.Name;
                colon.Force = model.Force;
                colon.Stamina = model.Endurance;
                colon.JobName = JobNameMapper.ToJobName(model.ProfessionId);
                team.ColonsTeam.Add(colon);
            }
            else
            {
                var colon = new Colon
                {
                    Name = model.Name,
                    Force = model.Force,
                    Stamina = model.Endurance,
                    JobName = JobNameMapper.ToJobName(model.ProfessionId),
                };
                team.ColonsTeam.Add(colon);
            }
        }

        // Validation du 5ème colon si rempli
        if (!string.IsNullOrWhiteSpace(OptionalColon?.Name))
        {
            if (TryValidateModel(OptionalColon))
            {
                team.ColonsTeam.Add(new Colon
                {
                    Name = OptionalColon.Name,
                    Force = OptionalColon.Force,
                    Stamina = OptionalColon.Endurance,
                    JobName = JobNameMapper.ToJobName(OptionalColon.ProfessionId)
                });
            }
            else
            {
                // Le 5ème colon est partiellement rempli => erreur
                ModelState.AddModelError(string.Empty, "Le 5ème colon est invalide.");
                return Page();
            }
        }

        await _teamService.AddTeamAsync(team);

        return RedirectToPage("/Teams");
    }



    public class InputTeamInfosModel
    {
        [Required] public string TeamName { get; set; }
        [BindProperty] public IFormFile? Banner { get; set; }
    }

    public class ColonInputModel
    {
        public string? TeamId { get; set; }

        public int Index { get; set; }
        
        public string? ColonId { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; }

        [Range(0, 3)] public int ProfessionId { get; set; }

        [Range(0, 7)] public int Force { get; set; }

        [Range(0, 7)] public int Endurance { get; set; }
    }
}