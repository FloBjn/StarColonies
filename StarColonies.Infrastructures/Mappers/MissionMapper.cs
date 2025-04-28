using StarColonies.Domains;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class MissionMapper
{
    public static Mission ToDomain(StarColoniesMission entity) => new Mission
    {
        MissionId = entity.MissionId,
        Name = entity.Name,
        MissionEnemies = entity.MissionEnemies.Select(EnemyMapper.ToDomain).ToList()
    };

    public static StarColoniesMission ToEntity(Mission mission , StarColoniesContext context)
    {
        var entity = new StarColoniesMission
        {
            MissionId = mission.MissionId,
            Name = mission.Name,
            MissionEnemies = new List<StarColoniesEnemy>()
        };
            
        foreach (var currentEnemy in mission.MissionEnemies)
        {
            var missionEntity = EnemyMapper.ToEntity(currentEnemy);

            var trackedEnemy = context.ChangeTracker
                .Entries<StarColoniesEnemy>()
                .FirstOrDefault(e => e.Entity.EnemyId == currentEnemy.EnemyId)?.Entity;

            if (trackedEnemy != null)
                entity.MissionEnemies.Add(trackedEnemy);
            else
            {
                context.Attach(missionEntity);
                entity.MissionEnemies.Add(missionEntity);
            }
        }    
            
        return entity;
    }
}