using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
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
    
    private async Task<StarColoniesTeam?> GetTeamEntityByIdAsync(string teamId)
    {
        var entity = await _context.ScTeam
            /*.Include(c => c.JobName)*/
            .Include(t => t.ColonsTeam)
            .Include(t => t.TeamBonusObjects)
            .FirstOrDefaultAsync(c => c.TeamId == teamId);
        return entity;
    }

    public async Task AddTeamAsync(Team team)
    {
        var entity = TeamMapper.ToEntity(team);
        _context.ScTeam.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamMaxLvlMissionAsync(Team team)
    {
        var teamDb = await GetTeamEntityByIdAsync(team.TeamId);
        if (teamDb == null) return;
        
        teamDb.LevelMaxAuthorized = team.LevelMaxAuthorized;
        
        _context.ScTeam.Update(teamDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamMembersAsync(Team team)
    {
        var teamDb = await GetTeamEntityByIdAsync(team.TeamId);
        if (teamDb == null) return;
        
        foreach (var colon in teamDb.ColonsTeam)
        {
            _context.Entry(colon).State = EntityState.Detached;
        }
        
        teamDb.ColonsTeam = team.ColonsTeam.Select(ColonMapper.ToEntity).ToList();
        
        _context.ScTeam.Update(teamDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamNameAsync(Team team)
    {
        var teamDb = await GetTeamEntityByIdAsync(team.TeamId);
        if (teamDb == null) return;
        
        teamDb.Name = team.Name;
        
        _context.ScTeam.Update(teamDb);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(Team team)
    {
        var entity = TeamMapper.ToEntity(team);
        _context.ScTeam.Remove(entity);
        await _context.SaveChangesAsync();
    }
}