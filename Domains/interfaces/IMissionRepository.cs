namespace StarColonies.Domains.interfaces;

public interface IMissionRepository
{
    Task<List<Mission>> GetAllAsync();
    
    Task<Mission?> GetByIdAsync(string missionId);
    
    Task AddMissionAsync(Mission mission);
    Task UpdateMissionNameAsync(Mission mission);
    Task UpdateMissionEnemiesAsync(Mission mission);
    Task DeleteMissionAsync(Mission mission);
}