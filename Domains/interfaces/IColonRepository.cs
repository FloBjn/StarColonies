namespace StarColonies.Domains.interfaces;

public interface IColonRepository
{
    Task <List<Colon>> GetAllColonsAsync();
    Task<Colon?> GetColonByIdAsync(string colonId);
    Task AddColonAsync(Colon colon);
    void UpdateColonAsync(Colon colon);
}