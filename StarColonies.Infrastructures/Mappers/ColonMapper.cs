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
        Teams = entity.Teams.Select(TeamMapper.ToDomain).ToList()
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
        Teams = colon.Teams.Select(TeamMapper.ToEntity).ToList()
    };
}