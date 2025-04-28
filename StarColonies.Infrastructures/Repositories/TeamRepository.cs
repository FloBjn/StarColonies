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
        var entity = TeamMapper.ToEntity(team, _context);
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
        
        teamDb.ColonsTeam = team.ColonsTeam
            .Select(colon => ColonMapper.ToEntity(colon, _context))
            .ToList();
    
        _context.ScTeam.Update(teamDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamObjectsAsync(Team team)
    {
        var teamDb = await GetTeamEntityByIdAsync(team.TeamId);
        if (teamDb == null) return;
        
        teamDb.TeamBonusObjects.Clear();
        
        foreach (var bonusObject in team.TeamBonusObjects)
        {
            var bonusEntity = BonusObjectMapper.ToEntity(bonusObject);
        
            // Regarde si l'objet exite déjà ou pas dans la liste
            if (!teamDb.TeamBonusObjects.Any(bo => bo.BonusObjectId == bonusEntity.BonusObjectId))
            {
                _context.Attach(bonusEntity); // Indique à Entity Framework que l'object/le lien exite déjà dans la base de donnée, pas besoin d'en rajouter un nouveau
                teamDb.TeamBonusObjects.Add(bonusEntity);  // Ajoute à la collection, à l'update, ça rajoutera juste ceux là, pas tout. Ca évite les doublons
            }
        }
        
        _context.ScTeam.Update(teamDb);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeamObjectsAsync(Team team)
    {
        var teamDb = await GetTeamEntityByIdAsync(team.TeamId);;
        if (teamDb == null) return;
        
        teamDb.TeamBonusObjects.Clear();
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
        var entity = TeamMapper.ToEntity(team, _context);
        _context.ScTeam.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task AddBonusObjectToTeamAsync(string teamId, string bonusObjectId)
    {
        var team = await _context.ScTeam
            .Include(t => t.TeamBonusObjects)
            .FirstOrDefaultAsync(t => t.TeamId == teamId);

        if (team == null) return;
        
        var bonusObject = await _context.ScBonusObject
            .FirstOrDefaultAsync(b => b.BonusObjectId == bonusObjectId);

        if (bonusObject == null) return;
        
        if (!team.TeamBonusObjects.Any(b => b.BonusObjectId == bonusObjectId))
        {
            team.TeamBonusObjects.Add(bonusObject);
            await _context.SaveChangesAsync();
        }
    }
}