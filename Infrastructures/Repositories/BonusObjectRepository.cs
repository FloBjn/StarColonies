using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class BonusObjectRepository : IBonusObjectRepository
{
    private readonly StarColoniesContext _context;
    public BonusObjectRepository(StarColoniesContext context)
    {
        _context = context;
    }
    public async Task<List<BonusObject>> GetAllBonusObjectsAsync()
    {
        var entities = await _context.ScBonusObject.ToListAsync();
        return entities.Select(BonusObjectMapper.ToDomain).ToList();
    }
    public async Task<BonusObject?> GetBonusObjectByIdAsync(string objectId)
    {
        var entity = await _context.ScBonusObject.FirstOrDefaultAsync(o => o.BonusObjectId == objectId);
        return entity is null ? null : BonusObjectMapper.ToDomain(entity);
    }
    
    private async Task<StarColoniesBonusObject?> GetBonusObjectEntityByIdAsync(string bonusObjectId)
    {
        var entity = await _context.ScBonusObject
            .FirstOrDefaultAsync(bo => bo.BonusObjectId == bonusObjectId);
        
        return entity;
    }

    public async Task AddBonusObjectAsync(BonusObject bonusObject)
    {
        var entity = BonusObjectMapper.ToEntity(bonusObject);
        _context.ScBonusObject.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBonusObjectNameAsync(BonusObject bonusObject)
    {
        var bonusObjectDb = await GetBonusObjectEntityByIdAsync(bonusObject.BonusObjectId);
        if (bonusObjectDb == null) return;
        
        bonusObjectDb.Name = bonusObjectDb.Name;
        
        _context.ScBonusObject.Update(bonusObjectDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBonusObjectPriceAsync(BonusObject bonusObject)
    {
        var bonusObjectDb = await GetBonusObjectEntityByIdAsync(bonusObject.BonusObjectId);
        if (bonusObjectDb == null) return;
        
        bonusObjectDb.Price = bonusObjectDb.Price;
        
        _context.ScBonusObject.Update(bonusObjectDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBonusObjectPerfBonusAsync(BonusObject bonusObject)
    {
        var bonusObjectDb = await GetBonusObjectEntityByIdAsync(bonusObject.BonusObjectId);
        if (bonusObjectDb == null) return;
        
        bonusObjectDb.BonusLevel = bonusObjectDb.BonusLevel;
        bonusObjectDb.BonusForce = bonusObjectDb.BonusForce;
        bonusObjectDb.BonusStamina = bonusObjectDb.BonusStamina;
        
        _context.ScBonusObject.Update(bonusObjectDb);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBonusObject(BonusObject bonusObject)
    {
        var entity = BonusObjectMapper.ToEntity(bonusObject);
        _context.ScBonusObject.Remove(entity);
        await _context.SaveChangesAsync();
    }
}