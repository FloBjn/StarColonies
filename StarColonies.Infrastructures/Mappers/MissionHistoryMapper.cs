using StarColonies.Domains;
using StarColonies.Infrastructures.data;
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

    public static StarColoniesMissionHistory ToEntity(MissionHistory missionHistory, StarColoniesContext context)
    {
        var missionEntity = MissionMapper.ToEntity(missionHistory.Mission, context);

        var trackedMission = context.ChangeTracker
        .Entries<StarColoniesMission>()
        .FirstOrDefault(e => e.Entity.MissionId == missionEntity.MissionId)
        ?.Entity;
        
        
        var teamEntity = TeamMapper.ToEntity(missionHistory.Team, context);

        var trackedTeam = context.ChangeTracker
        .Entries<StarColoniesTeam>()
        .FirstOrDefault(e => e.Entity.TeamId == teamEntity.TeamId)
        ?.Entity;

        return new StarColoniesMissionHistory
        {
            MissionHistoryId = missionHistory.MissionHistoryId,
            MissionId = missionHistory.MissionId,
            TeamId = missionHistory.TeamId,
            Mission = trackedMission ?? missionEntity,
            Team = trackedTeam ?? teamEntity,
            IsSuccess = missionHistory.IsSuccess,
        };        
        
    }
}