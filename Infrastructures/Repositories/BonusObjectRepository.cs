using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
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

    public async Task AddBonusObjectAsync(BonusObject bonusObject)
    {
        var entity = BonusObjectMapper.ToEntity(bonusObject);
        _context.ScBonusObject.Add(entity);
        await _context.SaveChangesAsync();
    }
}