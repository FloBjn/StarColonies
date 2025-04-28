using StarColonies.Domains;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class ColonMapper
{
    public static Colon ToDomain(StarColoniesColon entity) => new Colon
    {
        ColonId = entity.ColonId,
        Name = entity.Name,
        Level = entity.Level,
        Force = entity.Force,
        Stamina = entity.Stamina,
        NumberResource = entity.NumberResource,
        JobName = JobNameMapper.ToJobName(entity.JobName),
        Teams = entity.Teams.Select(team => new Team
        {
            TeamId = team.TeamId,
            Name = team.Name
        }).ToList()
    };

    public static StarColoniesColon ToEntity(Colon colon, StarColoniesContext context)
    {
        var entity = new StarColoniesColon
        {
            ColonId = colon.ColonId,
            Name = colon.Name,
            Level = colon.Level,
            Force = colon.Force,
            Stamina = colon.Stamina,
            NumberResource = colon.NumberResource,
            JobName = JobNameMapper.ToInt(colon.JobName),
            Teams = new List<StarColoniesTeam>()
        };
    
        foreach (var currentTeam in colon.Teams)
        {
            var bonusEntity = TeamMapper.ToEntity(currentTeam, context);
        
            var trackedBonus = context.ChangeTracker
                .Entries<StarColoniesTeam>()
                .FirstOrDefault(e => e.Entity.TeamId == currentTeam.TeamId)?.Entity;

            if (trackedBonus != null)
                entity.Teams.Add(trackedBonus);
            else
            {
                context.Attach(bonusEntity);
                entity.Teams.Add(bonusEntity);
            }
        }

        return entity;
    }
}