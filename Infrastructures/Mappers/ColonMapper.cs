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
        Job = JobMapper.ToDomain(entity.Job)
    };

    public static StarColoniesColon ToEntity(Colon colon) => new StarColoniesColon
    {
        Name = colon.Name,
        Force = colon.Force,
        Stamina = colon.Stamina,
        Job = JobMapper.ToEntity(colon.Job)
    };
}