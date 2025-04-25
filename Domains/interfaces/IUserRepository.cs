namespace StarColonies.Domains.interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetUserByIdAsync(int userId);
}