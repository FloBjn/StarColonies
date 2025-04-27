using StarColonies.Domains;
using StarColonies.Domains.interfaces;
using StarColonies.Infrastructures.Mappers;
using AppContext = StarColonies.Infrastructures.data.AppContext;

namespace StarColonies.Infrastructures.Repositories;

public class ColonRepository : IColonRepository
{
    
    private readonly AppContext _context;

    // Injecter le DbContext dans le repository
    public ColonRepository(AppContext context)
    {
        _context = context;
    }
    public async Task<string> AddColonAsync(Colon colon)
    {
        var starColoniesColon = ColonMapper.ToEntity(colon);
        _context.ScColon.Add(starColoniesColon);
        
        await _context.SaveChangesAsync();
        
        return starColoniesColon.ColonId;
    }
}