using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.data;
using StarColonies.Infrastructures.Mappers;

namespace StarColonies.Infrastructures.Repositories;

public class ColonRepository : IColonRepository
{
    
    private readonly AppDbContext _dbContext;

    // Injecter le DbContext dans le repository
    public ColonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<string> AddColonAsync(Colon colon)
    {
        var starColoniesColon = ColonMapper.ToEntity(colon);
        _dbContext.ScColon.Add(starColoniesColon);
        
        await _dbContext.SaveChangesAsync();
        
        return starColoniesColon.ColonId;
    }
}