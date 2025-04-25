using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class EnemyTypeMapper
{
    public static EnemyType ToDomain(StarColoniesEnemyType entity) => new EnemyType
    {
        Name = entity.Name
    };

    public static StarColoniesEnemyType ToEntity(EnemyType enemyType) => new StarColoniesEnemyType
    {
        Name = enemyType.Name
    };
}