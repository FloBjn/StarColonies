using StarColonies.Domains;
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

    public static StarColoniesColon ToEntity(Colon colon) => new StarColoniesColon
    {
        ColonId = colon.ColonId,
        Name = colon.Name,
        Level = colon.Level,
        Force = colon.Force,
        Stamina = colon.Stamina,
        NumberResource = colon.NumberResource,
        JobName = JobNameMapper.ToInt(colon.JobName),
        // posait probleme
        // Teams = colon.Teams.Select(team => new StarColoniesTeam
        // {
        //     TeamId = team.TeamId,
        //     Name = team.Name,
        //     LevelMaxAuthorized = team.LevelMaxAuthorized
        // }).ToList()
    };
}