using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class TestPageMission : PageModel
{
    private readonly IMissionRepository _missionRepository;

    public TestPageMission(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }

    public List<MissionViewModel> Missions { get; set; } = new();

    public async Task OnGetAsync()
    {
        var missions = await _missionRepository.GetAllAsync();

        Missions = missions.Select(m => new MissionViewModel
        {
            Id = m.Id,
            Nom = m.Nom,
            Niveau = m.Niveau,
            Defis = m.MissionBetes.Select(mb => new DefisViewModel
            {
                Id = mb.Defis.Id,
                Nom = mb.Defis.Nom,
                Force = mb.Defis.Force,
                Endurance = mb.Defis.Endurance
            }).ToList()
        }).ToList();
    }

    public class MissionViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }= string.Empty;
        public int Niveau { get; set; }
        public List<DefisViewModel> Defis { get; set; } = new();
    }

    public class DefisViewModel
    {
        public int Id { get; set; }
        
        public int Force { get; set; }
        
        public int Endurance { get; set; }
        
        public string Nom { get; set; }= string.Empty;
    }
}