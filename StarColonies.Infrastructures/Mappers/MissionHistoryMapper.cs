using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.Mappers;

public class MissionHistoryMapper
{
    public static MissionHistory ToDomain(StarColoniesMissionHistory entity) => new MissionHistory
    {
        MissionHistoryId = entity.MissionHistoryId,
        MissionId = entity.MissionId,
        Mission = MissionMapper.ToDomain(entity.Mission),
        TeamId = entity.TeamId,
        Team = TeamMapper.ToDomain(entity.Team),
        IsSuccess = entity.IsSuccess,
    };

    public static StarColoniesMissionHistory ToEntity(MissionHistory missionHistory) => new StarColoniesMissionHistory
    {
        MissionHistoryId = missionHistory.MissionHistoryId,
        MissionId = missionHistory.MissionId,
        Mission = MissionMapper.ToEntity(missionHistory.Mission),
        TeamId = missionHistory.TeamId,
        Team = TeamMapper.ToEntity(missionHistory.Team),
        IsSuccess = missionHistory.IsSuccess,
    };
}