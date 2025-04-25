using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StarColoniesContext _context;

    public UserRepository(StarColoniesContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var entity = await _context.ScUser
            .Include(u => u.UserColon)
            .ToListAsync();

        var toDomain = new List<User>();
        foreach (var user in entity)
        {
            
            toDomain.Add(UserMapper.ToDomain(user));
        }
        
        //pas sûre du return, je renvoie une liste possiblement vide, est-ce un problème?
        return toDomain;
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        var entity = await _context.ScUser
            .Include(u => u.UserColon)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        return entity is null ? null : UserMapper.ToDomain(entity);
    }
    
    /*
    public async Task AddAsync(User user)
    {
        var entity = UserMapper.ToEntity(user);
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
    }*/
}