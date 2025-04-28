using StarColonies.Domains;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class TeamMapper
{
    public static Team ToDomain(StarColoniesTeam entity) => new Team
    {
        TeamId = entity.TeamId,
        Name = entity.Name,
        
        TeamBonusObjects = entity.TeamBonusObjects.Select(BonusObjectMapper.ToDomain).ToList(),
        
        ColonsTeam = entity.ColonsTeam
            .Where(x => x != null)
            .Select(ColonMapper.ToDomain)
            .ToList(),
        
        LevelMaxAuthorized = entity.LevelMaxAuthorized,
    };

    public static StarColoniesTeam ToEntity(Team team, StarColoniesContext context)
    {
        var entity = new StarColoniesTeam
        {
            TeamId = team.TeamId,
            Name = team.Name,
            LevelMaxAuthorized = team.LevelMaxAuthorized,
            TeamBonusObjects = new List<StarColoniesBonusObject>(),
            ColonsTeam = new List<StarColoniesColon>()
        };

        //Attach existing BonusObjects
        foreach (var bonus in team.TeamBonusObjects)
        {
            var bonusEntity = BonusObjectMapper.ToEntity(bonus);
        
            var trackedBonus = context.ChangeTracker
                .Entries<StarColoniesBonusObject>()
                .FirstOrDefault(e => e.Entity.BonusObjectId == bonus.BonusObjectId)?.Entity;

            if (trackedBonus != null)
                entity.TeamBonusObjects.Add(trackedBonus);
            else
            {
                context.Attach(bonusEntity);
                entity.TeamBonusObjects.Add(bonusEntity);
            }
        }

        //Attach existing Colons
        foreach (var colon in team.ColonsTeam)
        {
            var colonEntity = ColonMapper.ToEntity(colon, context);

            var trackedColon = context.ChangeTracker
                .Entries<StarColoniesColon>()
                .FirstOrDefault(e => e.Entity.ColonId == colon.ColonId)?.Entity;

            if (trackedColon != null)
                entity.ColonsTeam.Add(trackedColon);
            else
            {
                context.Attach(colonEntity);
                entity.ColonsTeam.Add(colonEntity);
            }
        }

        return entity;
    }
}