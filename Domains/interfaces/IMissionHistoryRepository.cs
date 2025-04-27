namespace StarColonies.Domains.interfaces;

public interface IMissionHistoryRepository
{
    Task<IList<MissionHistory>> GetMissionsHistoryAsync();
    Task <MissionHistory?> GetMissionHistoryByIdAsync(string missionHistoryId);
    Task<IList<MissionHistory>> GetMissionsHistoryByTeamIdAsync(string teamId);
    Task AddMissionHistoryAsync(MissionHistory missionHistory);
}