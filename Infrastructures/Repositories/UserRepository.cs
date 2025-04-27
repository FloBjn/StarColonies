using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Entities;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StarColoniesContext _dbContext;
    private readonly UserManager<StarColoniesUser> _userManager; 
    
    public UserRepository(UserManager<StarColoniesUser> userManager, StarColoniesContext dbContext)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var entities = await _dbContext.ScUser
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .ToListAsync();
        
        //pas sûre du return, je renvoie une liste possiblement vide, est-ce un problème?
        return entities.Select(UserMapper.ToDomain).ToList();
    }
    
    public async Task<User?> GetConnectedUser(ClaimsPrincipal user)
    {
        var userConnected = new User();
        
        var userDb = await _userManager.GetUserAsync(user);
        if (userDb != null)
        {
           return await GetUserByIdAsync(userDb.Id);
        }
        
        return null;
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        var entity = await _dbContext.ScUser
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return entity is null ? null : UserMapper.ToDomain(entity);
    }
    
    public async Task AddAsync(User user)
    {
        var entity = UserMapper.ToEntity(user);
        _dbContext.ScUser.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public void ModifyUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}