using System.Security.Claims;

namespace StarColonies.Domains.interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetUserByIdAsync(string userId);
    Task AddAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);
    Task<User?> GetUserConnectedAsync(ClaimsPrincipal user);
}