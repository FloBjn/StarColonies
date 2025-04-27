using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class EnemyRepository : IEnemyRepository
{
    private readonly StarColoniesContext _context;

    public EnemyRepository(StarColoniesContext context)
    {
        _context = context;
    }
    public async Task<IList<Enemy>> GetAllEnemyAsync()
    {
        var entities = await _context.ScEnemy
            .Include(e => e.EnemyType)
            .ToListAsync();
        return entities.Select(EnemyMapper.ToDomain).ToList();
    }
}