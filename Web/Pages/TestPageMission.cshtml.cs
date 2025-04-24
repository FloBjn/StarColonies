using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains.interfaces;
using StarColonies.Web.ViewModels;

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
}