using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class ColonMapper
{
    public static Colon ToDomain(StarColoniesColon entity) => new Colon
    {
        Name = entity.Name,
        Force = entity.Force,
        Stamina = entity.Stamina,
        JobName = JobNameMapper.ToJobName(entity.JobName),
        Teams = entity.Teams.Select(TeamMapper.ToDomain).ToList()
    };

    public static StarColoniesColon ToEntity(Colon colon) => new StarColoniesColon
    {
        Name = colon.Name,
        Force = colon.Force,
        Stamina = colon.Stamina,
        JobName = JobNameMapper.ToInt(colon.JobName),
        Teams = colon.Teams.Select(TeamMapper.ToEntity).ToList()
    };
}