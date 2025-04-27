using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class MissionRepository : IMissionRepository
{
    private readonly AppDbContext _dbContext;

    public MissionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Mission>> GetAllAsync()
    {
        var entities = await _dbContext.ScMission
            .Include(e => e.MissionEnemies)
            .ToListAsync();
        
        //pas sûre du return, je renvoie une liste possiblement vide, est-ce un problème?
        return entities.Select(MissionMapper.ToDomain).ToList();
    }

    public async Task<Mission?> GetByIdAsync(string missionId)
    {
        var entity = await _dbContext.ScMission
            .Include(e => e.MissionEnemies)
            .FirstOrDefaultAsync(m => m.MissionId == missionId);

        
        //pas sûre du return, je renvoie une liste possiblement vide, est-ce un problème?
        return entity is null ? null : MissionMapper.ToDomain(entity);
        
    }

    public Task AddMissionAsync(Mission mission)
    {
        throw new NotImplementedException();
    }

    public async void UpdateMissionAsync(Mission mission)
    {
        var entity = MissionMapper.ToEntity(mission);
        _context.ScMission.Add(entity);
        await _context.SaveChangesAsync();
    }

    public void DeleteMissionAsync(Mission mission)
    {
        throw new NotImplementedException();
    }
}