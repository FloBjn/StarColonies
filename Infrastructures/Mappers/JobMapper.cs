using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class JobMapper
{
    public static Job ToDomain(StarColoniesJob entity) => new Job
    {
        Name = entity.Name
    };

    public static StarColoniesJob ToEntity(Job job) => new StarColoniesJob
    {
        Name = job.Name
    };
}