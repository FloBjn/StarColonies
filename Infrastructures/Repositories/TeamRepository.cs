using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class TeamRepository :ITeamRepository
{
    private readonly StarColoniesContext _context;
    public TeamRepository(StarColoniesContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetAllTeamsAsync()
    {
        var entities = await _context.ScTeam
            .Include(t =>t.ColonsTeam)
            .Include(t => t.TeamBonusObjects)  
            .ToListAsync();
        return entities.Select(TeamMapper.ToDomain).ToList();
    }
    public async Task<Team?> GetByIdAsync(string teamId)
    {
        var entity = await _context.ScTeam
            .Include(t =>t.ColonsTeam)
            .Include(t => t.TeamBonusObjects)  
            .FirstOrDefaultAsync(t => t.TeamId == teamId);
        return entity is null ? null : TeamMapper.ToDomain(entity);
    }

    public async Task AddTeamAsync(Team team)
    {
        var entity = TeamMapper.ToEntity(team);
        _context.ScTeam.Add(entity);
        await _context.SaveChangesAsync();
    }
}