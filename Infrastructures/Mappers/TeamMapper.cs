using StarColonies.Domains;
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

    public static StarColoniesTeam ToEntity(Team team) => new StarColoniesTeam
    {
        TeamId = team.TeamId,
        Name = team.Name,
        TeamBonusObjects = team.TeamBonusObjects.Select(BonusObjectMapper.ToEntity).ToList(),
        ColonsTeam = team.ColonsTeam.Select(ColonMapper.ToEntity).ToList(),
        LevelMaxAuthorized = team.LevelMaxAuthorized,
    };
}