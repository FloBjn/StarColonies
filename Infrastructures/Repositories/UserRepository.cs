using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;
using AppContext = StarColonies.Infrastructures.data.AppContext;

namespace StarColonies.Infrastructures.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppContext _context;

    public UserRepository(AppContext context)
    {
        _context = context;
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
        var entity = await _context.ScUser
            .Include(u => u.UserColon)
            .ThenInclude(c=> c.Teams)
            .FirstOrDefaultAsync(u => u.Id == userId);

        return entity is null ? null : UserMapper.ToDomain(entity);
    }
    
    public async Task AddAsync(User user)
    {
        var entity = UserMapper.ToEntity(user);
        _context.ScUser.Add(entity);
        await _context.SaveChangesAsync();
    }
}