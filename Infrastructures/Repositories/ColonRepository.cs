using StarColonies.Domains;
using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class ColonRepository : IColonRepository
{
    private readonly StarColoniesContext _context;
    public ColonRepository(StarColoniesContext context)
    {
        _context = context;
    }
    public async Task<List<Colon>> GetAllColonsAsync()
    {
        var entities = await _context.ScColon
            /*.Include(c => c.JobName)*/
            .Include(c => c.Teams)
            .ToListAsync();
        return entities.Select(ColonMapper.ToDomain).ToList();
    }
    public async Task<Colon?> GetColonByIdAsync(string colonId)
    {
        var entity = await GetColonEntityByIdAsync(colonId);
        return entity is null ? null : ColonMapper.ToDomain(entity);
    }
    
    private async Task<StarColoniesColon?> GetColonEntityByIdAsync(string colonId)
    {
        var entity = await _context.ScColon
            /*.Include(c => c.JobName)*/
            .Include(c => c.Teams)
            .FirstOrDefaultAsync(c => c.ColonId == colonId);
        return entity;
    }
    public async Task AddColonAsync(Colon colon)
    {
        var entity = ColonMapper.ToEntity(colon);
        _context.ScColon.Add(entity);
        await _context.SaveChangesAsync();
    }

    public void UpdateColonAsync(Colon colon)
    {
        throw new NotImplementedException();
    }

    public async Task ModifyColonPerfAsync(Colon colon)
    {
        var colonDb = await GetColonEntityByIdAsync(colon.ColonId);
        if (colonDb == null) return;
        
        colonDb.Force = colon.Force;
        colonDb.Stamina = colon.Stamina;
        _context.ScColon.Update(colonDb);
        await _context.SaveChangesAsync();
    }
    
    public async Task ModifyColonNameAsync(Colon colon)
    {
        var colonDb = await GetColonEntityByIdAsync(colon.ColonId);
        if (colonDb == null) return;
        
        colonDb.Name = colon.Name;
        
        _context.ScColon.Update(colonDb);
        await _context.SaveChangesAsync();
    }
}