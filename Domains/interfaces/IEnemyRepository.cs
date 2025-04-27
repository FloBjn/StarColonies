namespace StarColonies.Domains.interfaces;

public interface IEnemyRepository
{
    Task <IList<Enemy>> GetAllEnemyAsync();
}