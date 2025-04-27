using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
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
            .ToListAsync();
        return entities.Select(EnemyMapper.ToDomain).ToList();
    }

    public async Task<Enemy?> GetByIdAsync(string enemyId)
    {
        var entity = await _context.ScEnemy
            .FirstOrDefaultAsync(e => e.EnemyId == enemyId);
        
        return entity is null ? null : EnemyMapper.ToDomain(entity);
    }
    
    private async Task<StarColoniesEnemy?> GetEnemyEntityByIdAsync(string enemyId)
    {
        var entity = await _context.ScEnemy
            .FirstOrDefaultAsync(e => e.EnemyId == enemyId);
        
        return entity;
    }

    public async Task AddEnemyAsync(Enemy enemy)
    {
        var entity = EnemyMapper.ToEntity(enemy);
        await _context.ScEnemy.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnemyNameAsync(Enemy enemy)
    {
        var enemyDb = await GetEnemyEntityByIdAsync(enemy.EnemyId);
        if (enemyDb == null) return;
        
        enemyDb.Name = enemy.Name;
        
        _context.ScEnemy.Update(enemyDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnemyPerfAsync(Enemy enemy)
    {
        var enemyDb = await GetEnemyEntityByIdAsync(enemy.EnemyId);
        if (enemyDb == null) return;
        
        enemyDb.Name = enemy.Name;
        
        _context.ScEnemy.Update(enemyDb);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnemyTypeAsync(Enemy enemy)
    {
        var enemyDb = await GetEnemyEntityByIdAsync(enemy.EnemyId);
        if (enemyDb == null) return;
        
        enemyDb.EnemyTypeNameId = EnemyTypeNameMapper.ToInt(enemy.EnemyTypeName);
        
        _context.ScEnemy.Update(enemyDb);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEnemyAsync(Enemy enemy)
    {
        var entity = EnemyMapper.ToEntity(enemy);
        _context.ScEnemy.Remove(entity);
        await _context.SaveChangesAsync();
    }
}