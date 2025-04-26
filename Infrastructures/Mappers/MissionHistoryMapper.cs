using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class MissionHistoryMapper
{
    public static MissionHistory ToDomain(StarColoniesMissionHistory entity) => new MissionHistory
    {
        Mission = MissionMapper.ToDomain(entity.Mission),
        Team = TeamMapper.ToDomain(entity.Team),
        IsSuccess = entity.IsSuccess,
    };

    public static StarColoniesMissionHistory ToEntity(MissionHistory missionHistory) => new StarColoniesMissionHistory
    {
        Mission = MissionMapper.ToEntity(missionHistory.Mission),
        Team = TeamMapper.ToEntity(missionHistory.Team),
        IsSuccess = missionHistory.IsSuccess,
    };
}