using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;

namespace StarColonies.Web.Pages;

public class Missions : PageModel
{
    [BindProperty]
    public required IList<Mission> MissionsList { get; set; } = new List<Mission>();
    [BindProperty]
    public string Action { get; set; }

    public string MissionId { get; set; }

    private IMissionRepository _missionRepository;

    public Missions(IMissionRepository missionRepository)
    {
        _missionRepository = missionRepository;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        MissionsList = await _missionRepository.GetAllAsync();
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string missionId)
    {
        switch (Action)
        {
            case "Modify":
                Console.WriteLine(Action);
                Console.WriteLine(MissionId);
                HttpContext.Session.SetString("MissionId", MissionId);
                return RedirectToPage("/ModifyMission");
            case "Delete":
                break;
        }
        
        return Page();
    }
}