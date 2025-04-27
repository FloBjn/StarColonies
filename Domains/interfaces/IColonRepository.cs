namespace StarColonies.Domains.interfaces;

public interface IColonRepository
{
    public Task<string> AddColonAsync(Colon colon);
}