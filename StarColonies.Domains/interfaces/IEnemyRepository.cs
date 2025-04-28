namespace StarColonies.Domains.interfaces;

public interface IEnemyRepository
{
    Task <IList<Enemy>> GetAllEnemyAsync();
    
    Task<Enemy?> GetByIdAsync(string enemyId);
    Task AddEnemyAsync(Enemy enemy);
    Task UpdateEnemyNameAsync(Enemy enemy);
    Task UpdateEnemyPerfAsync(Enemy enemy);
    Task UpdateEnemyTypeAsync(Enemy enemy);
    Task DeleteEnemyAsync(Enemy enemy);
}