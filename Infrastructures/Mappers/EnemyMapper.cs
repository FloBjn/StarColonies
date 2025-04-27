using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class EnemyMapper
{
    public static Enemy ToDomain(StarColoniesEnemy entity) => new Enemy
    {
        EnemyId = entity.EnemyId,
        Name = entity.Name,
        Force = entity.Force,
        Stamina = entity.Stamina,
        EnemyTypeName = EnemyTypeNameMapper.ToEnemyTypeName(entity.EnemyTypeNameId)

    };

    public static StarColoniesEnemy ToEntity(Enemy enemy) => new StarColoniesEnemy
    {
        EnemyId = enemy.EnemyId,
        Name = enemy.Name,
        Force = enemy.Force,
        Stamina = enemy.Stamina,
        EnemyTypeNameId = EnemyTypeNameMapper.ToInt(enemy.EnemyTypeName)
    };
}