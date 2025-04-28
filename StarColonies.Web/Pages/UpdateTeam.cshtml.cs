using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Web.Pages;

public class UpdateTeam : PageModel
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    
    public required Team? ModifyingTeam {get; set;}
    [BindProperty] 
    public required InputColonModel ColonModelList { get; set; } = new();
    [BindProperty]
    public required InputTeamModel InputTeamInfosModel {get; set;} = new();
    public required User? UserConnected { get; set; }
    public required string IdModifyingTeam { get; set; }
    [BindProperty]
    public string Action { get; set; }
    
    public UpdateTeam(ITeamRepository teamRepository, IUserRepository userRepository)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await SetConnectedUser();
        var monId = HttpContext.Session.GetString("SelectedId");
        Console.WriteLine(monId);
        if (!string.IsNullOrEmpty(monId))
        {
            ModifyingTeam = await _teamRepository.GetByIdAsync(monId);
            if (ModifyingTeam == null)
            {
                return Page();
            }
            IdModifyingTeam = monId;
        }
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        await SetConnectedUser();
       
        ModifyingTeam = await _teamRepository.GetByIdAsync(ColonModelList.TeamId);
        
        ModelState.Clear();

        switch (Action)
        {
            case "ModifyInfos":
                if (!TryValidateModel(InputTeamInfosModel))
                {
                    return Page();
                }
                ModifyingTeam.Name = InputTeamInfosModel.TeamName;
                await _teamRepository.UpdateTeamNameAsync(ModifyingTeam);
                break;
            case "ModifyColon":
                if (!TryValidateModel(ColonModelList) || !HasModelChanged(ColonModelList))
                {
                    return Page(); 
                }
        
                await UpdateColon(ColonModelList);
                break;
            default: return Page();
        }
        
        return Page();
    }

    private bool EnoughColon()
    {
        return ModifyingTeam.ColonsTeam.Count is 4 or 5;
    }

    private bool HasModelChanged(InputColonModel model)
    {
        if (ModifyingTeam.ColonsTeam.ElementAtOrDefault(model.Index) != null)
        {
            Console.WriteLine("profid : " + model.ProfessionId);
            return JobNameMapper.ToJobName(model.ProfessionId) != ModifyingTeam.ColonsTeam[model.Index].JobName ||
                   model.Name != ModifyingTeam.ColonsTeam[model.Index].Name ||
                   model.Force != ModifyingTeam.ColonsTeam[model.Index].Force ||
                   model.Endurance != ModifyingTeam.ColonsTeam[model.Index].Stamina;
        }

        return true;
    }

    private bool CheckProfConstraint()
    { 
        var jobsWithTooMany = ModifyingTeam.ColonsTeam
            .GroupBy(c => c.JobName) // Groupement par JobName
            .Where(g => g.Count() > 2) // Cherche les groupes avec plus de 2 colons
            .ToList();
        Console.WriteLine("jobsWithTooMany : " + jobsWithTooMany.Count);
        if (jobsWithTooMany.Count == 0)
        {
            return true;
        }
        else
        {
            foreach (var jobGroup in jobsWithTooMany)
            {
                ModelState.AddModelError("", $"Le job {jobGroup.Key} ne peut pas apparaître plus de 2 fois.");
            }
            return false;
        }
    }

    private async Task UpdateColon(InputColonModel model)
    {
        var index = model.Index;

        if (ModifyingTeam.ColonsTeam.ElementAtOrDefault(index) == null)
        {
            Console.WriteLine("creation Colon");
            var newColon = new Colon
            {
                Name = model.Name,
                Force = model.Force,
                Stamina = model.Endurance,
                JobName = JobNameMapper.ToJobName(model.ProfessionId)
            };
            if (ModifyingTeam.ColonsTeam == null)
            {
                var newlist = new List<Colon> { newColon };
                ModifyingTeam.ColonsTeam = newlist;
            }
            else
            {
                ModifyingTeam.ColonsTeam.Add(newColon);
            }
        }else if (ModifyingTeam.ColonsTeam[index].ColonId == UserConnected.ColonId)
        {
            // Détacher l'entité existante pour éviter le suivi multiple
            // _context.Entry(colon).State = EntityState.Detached;
            ModifyingTeam.ColonsTeam[index].Name = model.Name;
            ModifyingTeam.ColonsTeam[index].Force = model.Force;
            ModifyingTeam.ColonsTeam[index].Stamina = model.Endurance;
            ModifyingTeam.ColonsTeam[index].JobName = JobNameMapper.ToJobName(model.ProfessionId);
            UserConnected.UserColon = ModifyingTeam.ColonsTeam[index];
            await _userRepository.UpdateUserAsync(UserConnected);
            // await _colonRepository.UpdateColonPerfAsync(colon);

        }
        else
        {
            // Détacher l'entité existante pour éviter le suivi multiple
            // _context.Entry(colon).State = EntityState.Detached;
            ModifyingTeam.ColonsTeam[index].Name = model.Name;
            ModifyingTeam.ColonsTeam[index].Force = model.Force;
            ModifyingTeam.ColonsTeam[index].Stamina = model.Endurance;
            ModifyingTeam.ColonsTeam[index].JobName = JobNameMapper.ToJobName(model.ProfessionId);
            // await _colonRepository.UpdateColonPerfAsync(colon);
        }

        if (CheckProfConstraint())
        {
            await _teamRepository.UpdateTeamMembersAsync(ModifyingTeam);
        }
    }
    
        private async Task SetConnectedUser()
        {
            UserConnected = await _userRepository.GetUserConnectedAsync(User);
        }

    public class InputColonModel : IValidatableObject
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Profession")]
        public int ProfessionId { get; set; } = 0;
        [Range(0, 7)]
        [Display(Name = "Force")]
        public int Force { get; set; }
        [Range(0, 7)]
        [Display(Name = "Endurance")]
        public int Endurance { get; set; }
        // public string ColonId { get; set; } = string.Empty;
        [Required]
        public string TeamId { get; set; }
        [Required]
        public int Index { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Force + Endurance != 7)
            {
                yield return new ValidationResult(
                    $"La somme de la Force et de l'Endurance doit être égale à 7. pour le colon {Name}",
                    new[] { nameof(Force)/*, nameof(Endurance)*/ });
            }
        }
    }

    public class InputTeamModel
    {
        [Required]
        [Display(Name = "TeamName")]
        public string TeamName { get; set; }
        
        [Display(Name = "Banner")]
        [DataType(DataType.ImageUrl)]
        
        public IFormFile? Banner { get; set; }

    }
}