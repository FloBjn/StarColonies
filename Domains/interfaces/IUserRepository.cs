using System.Security.Claims;

namespace StarColonies.Domains.interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetUserByIdAsync(string userId);
    Task AddAsync(User user);
    void ModifyUserAsync(User user);
    void DeleteUserAsync(User user);
    Task<User?> GetConnectedUser(ClaimsPrincipal user);
}