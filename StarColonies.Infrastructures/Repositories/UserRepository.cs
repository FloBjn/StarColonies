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
    private readonly StarColoniesContext _context;
    private readonly UserManager<StarColoniesUser> _userManager;

    public UserRepository(StarColoniesContext dbContext, UserManager<StarColoniesUser> userManager)
    {
        _context = dbContext;
        _userManager = userManager;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var entities = await _context.ScUser
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .ToListAsync();
        
        //pas sûre du return, je renvoie une liste possiblement vide, est-ce un problème?
        return entities.Select(UserMapper.ToDomain).ToList();
    }

    public async Task<User?> GetUserByIdAsync(string userId)
    {
        var entity = await GetUserEntityByIdAsync(userId);

        return entity is null ? null : UserMapper.ToDomain(entity);
    }
    
    private async Task<StarColoniesUser?> GetUserEntityByIdAsync(string userId)
    {
        var entity = await _context.ScUser
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return entity;
    }
    
    public async Task AddAsync(User user)
    {
        var entity = UserMapper.ToEntity(user);
        await _context.ScUser.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        //Console.WriteLine("Userconnected : " + user == null);
        var userDb = await GetUserEntityByIdAsync(user.Id);
        if (userDb == null) return;
        
        userDb.UserName = user.Name;
        userDb.Email = user.Email;
        userDb.BirthDate = user.BirthDate;
        
        await _userManager.UpdateAsync(userDb);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        var entity = UserMapper.ToEntity(user);
        _context.ScUser.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserConnectedAsync(ClaimsPrincipal user)
    {
        var userDb = await _userManager.GetUserAsync(user);
        if (userDb != null)
        {
            return await GetUserByIdAsync(userDb.Id);
            
        }
        return null;
    }
    
    public async Task<User?> GetUserConnectedNotTrackedAsync(ClaimsPrincipal user)
    {
        var userDb = await _userManager.GetUserAsync(user);
        if (userDb != null)
        {
            return await GetUserByIdNotTrackedAsync(userDb.Id);
            
        }
        return null;
    }
    
    private async Task<StarColoniesUser?> GetUserEntityByIdNotTrackedAsync(string userId)
    {
        var entity = await _context.ScUser.AsNoTracking()
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return entity;
    }
    
    private async Task<User?> GetUserByIdNotTrackedAsync(string userId)
    {
        var entity = await GetUserEntityByIdAsync(userId);

        return entity is null ? null : UserMapper.ToDomain(entity);
    }
}