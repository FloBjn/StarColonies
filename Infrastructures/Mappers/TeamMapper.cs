using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class TeamMapper
{
    public static Team ToDomain(StarColoniesTeam entity) => new Team
    {
        Name = entity.Name
    };

    public static StarColoniesTeam ToEntity(Team team) => new StarColoniesTeam
    {
        Name = team.Name
    };
}