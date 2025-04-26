using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class EnemyMapper
{
    public static Enemy ToDomain(StarColoniesEnemy entity) => new Enemy
    {
        Name = entity.Name,
        EnemyType = EnemyTypeNameMapper.ToEnemyTypeName(entity.EnemyType)

    };

    public static StarColoniesEnemy ToEntity(Enemy enemy) => new StarColoniesEnemy
    {
        Name = enemy.Name,
        EnemyType = EnemyTypeNameMapper.ToInt(enemy.EnemyType)
    };
}