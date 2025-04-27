namespace StarColonies.Domains.interfaces;

public interface IMissionRepository
{
    Task<List<Mission>> GetAllAsync();
    
    Task<Mission?> GetByIdAsync(string missionId);
    
    Task AddMissionAsync(Mission mission);
    void UpdateMissionAsync(Mission mission);
    void DeleteMissionAsync(Mission mission);
}