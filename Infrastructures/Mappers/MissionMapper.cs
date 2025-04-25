using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class MissionMapper
{
    public static Mission ToDomain(StarColoniesMission entity) => new Mission
    {
        Name = entity.Name
    };

    public static StarColoniesMission ToEntity(Mission mission) => new StarColoniesMission
    {
        Name = mission.Name
    };
}