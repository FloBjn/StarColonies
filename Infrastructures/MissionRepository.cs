using Microsoft.EntityFrameworkCore;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;

namespace StarColonies.Infrastructures;

public class MissionRepository : IMissionRepository
{
    private readonly StarColoniesContext _context;

    public MissionRepository(StarColoniesContext context)
    {
        _context = context;
    }
    
    public async Task<List<Mission>> GetAllAsync()
    {
        return await _context.Missions
            .Include(m => m.MissionBetes)
            .ThenInclude(mb => mb.Defis)
            .ToListAsync();
    }

    public async Task<Mission?> GetByIdAsync(int id)
    {
        return await _context.Missions
            .Include(m => m.MissionBetes)
            .ThenInclude(mb => mb.Defis)
            .ThenInclude(d => d.TypeDefis)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}