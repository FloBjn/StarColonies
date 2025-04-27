using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class MissionHistoryRepository : IMissionHistoryRepository
{
    private readonly StarColoniesContext _context;

    public MissionHistoryRepository(StarColoniesContext context)
    {
        _context = context;
    }
    
    public async Task<IList<MissionHistory>> GetMissionsHistoryAsync()
    {
        var entities = await _context.ScMissionHistory
            .Include(m => m.Mission)
            .Include(m => m.Team)
            .ToListAsync();
        return entities.Select(MissionHistoryMapper.ToDomain).ToList();
    }
    public async Task<MissionHistory?> GetMissionHistoryByIdAsync(string missionHistoryId)
    {
        var entity = await _context.ScMissionHistory
            .Include(m => m.Mission)
            .Include(m => m.Team)
            .FirstOrDefaultAsync(m=> m.MissionHistoryId == missionHistoryId);
        return entity is null ? null : MissionHistoryMapper.ToDomain(entity);
    }

    public async Task AddMissionHistoryAsync(MissionHistory missionHistory)
    {
        var entity = MissionHistoryMapper.ToEntity(missionHistory);
        _context.ScMissionHistory.Add(entity);
        await _context.SaveChangesAsync();
    }
}