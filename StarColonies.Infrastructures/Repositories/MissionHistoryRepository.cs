using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class MissionHistoryRepository(StarColoniesContext context) : IMissionHistoryRepository
{
    public async Task<IList<MissionHistory>> GetMissionsHistoryAsync()
    {
        var entities = await context.ScMissionHistory
            .Include(m => m.Mission)
            .Include(m => m.Team)
            .ToListAsync();
        return entities.Select(MissionHistoryMapper.ToDomain).ToList();
    }
    public async Task<MissionHistory?> GetMissionHistoryByIdAsync(string missionHistoryId)
    {
        var entity = await context.ScMissionHistory
            .Include(m => m.Mission)
            .Include(m => m.Team)
            .FirstOrDefaultAsync(m=> m.MissionHistoryId == missionHistoryId);
        return entity is null ? null : MissionHistoryMapper.ToDomain(entity);
    }

    public async Task<IList<MissionHistory>> GetMissionsHistoryByTeamIdAsync(string teamId)
    {
        var entities = await context.ScMissionHistory
            .Where(mh => mh.TeamId == teamId)
            .ToListAsync();
        
        return entities.Select(MissionHistoryMapper.ToDomain).ToList();
    }

    public async Task AddMissionHistoryAsync(MissionHistory missionHistory)
    {
        var entity = MissionHistoryMapper.ToEntity(missionHistory);
        context.ScMissionHistory.Add(entity);
        await context.SaveChangesAsync();
    }
}