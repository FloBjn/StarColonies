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
        _context.ScUser.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task ModifyUserAsync(User user)
    {
        Console.WriteLine("Userconnected : " + user == null);
        var userDb = await GetUserEntityByIdAsync(user.Id);
        if (userDb == null) return;
        
        userDb.UserName = user.Name;
        userDb.Email = user.Email;
        userDb.BirthDate = user.BirthDate;
        
        var result = await _userManager.UpdateAsync(userDb);
        await _context.SaveChangesAsync();
    }

    public void DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
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
}