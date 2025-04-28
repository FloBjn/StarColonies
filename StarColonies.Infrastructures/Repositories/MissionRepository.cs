using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class MissionRepository : IMissionRepository
{
    private readonly StarColoniesContext _dbContext;

    public MissionRepository(StarColoniesContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Mission>> GetAllAsync()
    {
        var entities = await _dbContext.ScMission
            .Include(e => e.MissionEnemies)
            .ToListAsync();
        
        return entities.Select(MissionMapper.ToDomain).ToList();
    }

    public async Task<Mission?> GetByIdAsync(string missionId)
    {
        var entity = await _dbContext.ScMission
            .Include(e => e.MissionEnemies)
            .FirstOrDefaultAsync(m => m.MissionId == missionId);
        
        return entity is null ? null : MissionMapper.ToDomain(entity);
    }
    
    private async Task<StarColoniesMission?> GetMissionEntityByIdAsync(string missionId)
    {
        var entity = await _dbContext.ScMission
            .Include(m=> m.MissionEnemies)
            .FirstOrDefaultAsync(m => m.MissionId == missionId);
        
        return entity;
    }

    public async Task AddMissionAsync(Mission mission)
    {
        var entity = MissionMapper.ToEntity(mission);
        await _dbContext.ScMission.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMissionNameAsync(Mission mission)
    {
        var missionDb = await GetMissionEntityByIdAsync(mission.MissionId);
        if (missionDb == null) return;
        
        missionDb.Name = mission.Name;
        
        _dbContext.ScMission.Update(missionDb);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMissionEnemiesAsync(Mission mission)
    {
        var missionDb = await GetMissionEntityByIdAsync(mission.MissionId);
        if (missionDb == null) return;
        
        missionDb.MissionEnemies = mission.MissionEnemies.Select(EnemyMapper.ToEntity).ToList();
        
        _dbContext.ScMission.Update(missionDb);
        await _dbContext.SaveChangesAsync();
    }
    

    public async Task DeleteMissionAsync(Mission mission)
    {
        var entity = MissionMapper.ToEntity(mission);
        _dbContext.ScMission.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

}