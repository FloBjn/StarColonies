using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class TeamMapper
{
    public static Team ToDomain(StarColoniesTeam entity) => new Team
    {
        Name = entity.Name,
        TeamBonusObjects = entity.TeamBonusObjects.Select(BonusObjectMapper.ToDomain).ToList(),
        LevelMaxAuthorized = entity.LevelMaxAuthorized,
    };

    public static StarColoniesTeam ToEntity(Team team) => new StarColoniesTeam
    {
        Name = team.Name,
        TeamBonusObjects = team.TeamBonusObjects.Select(BonusObjectMapper.ToEntity).ToList(),
        LevelMaxAuthorized = team.LevelMaxAuthorized,
    };
}