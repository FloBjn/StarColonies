namespace StarColonies.Domains.interfaces;

public interface IMissionHistoryRepository
{
    Task<IList<MissionHistory>> GetMissionsHistoryAsync();
    Task <MissionHistory?> GetMissionHistoryByIdAsync(string missionHistoryId);
    Task AddMissionHistoryAsync(MissionHistory missionHistory);
}