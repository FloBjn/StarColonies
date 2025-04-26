using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class TestPageMission : PageModel
{
    private readonly IMissionRepository _missionRepository;

    
    public TestPageMission(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }

    public async Task<List<Mission>> GetAllMissions()
    {
        return await _missionRepository.GetAllAsync();
    }
    
}