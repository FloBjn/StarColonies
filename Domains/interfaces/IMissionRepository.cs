namespace StarColonies.Domains.interfaces;

public interface IMissionRepository
{
    Task<List<Mission>> GetAllAsync();
    
    Task<Mission?> GetByIdAsync(int missionId);

}