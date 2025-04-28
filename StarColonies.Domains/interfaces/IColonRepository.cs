namespace StarColonies.Domains.interfaces;

public interface IColonRepository
{
    Task <List<Colon>> GetAllColonsAsync();
    Task<Colon?> GetColonByIdAsync(string colonId);
    Task AddColonAsync(Colon colon);
    Task UpdateColonPerfAsync(Colon colon);
    Task UpdateColonNameAsync(Colon colon);
    Task UpdateColonNumberResource(Colon colon);
    void DetacheTrackingColon(string modelColonId);
    Task<Colon?> GetColonByIdNotTrackedAsync(string colonId);
}