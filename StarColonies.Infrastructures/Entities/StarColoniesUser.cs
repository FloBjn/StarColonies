using Microsoft.AspNetCore.Identity;

namespace StarColonies.Infrastructures.Entities;

public class StarColoniesUser : IdentityUser
{
    public string? Avatar { get; set; }
    public required DateOnly BirthDate { get; set; }
    public bool IsAdmin { get; set; }
    
    public required string ColonId { get; set; }
    
    public required StarColoniesColon UserColon { get; set; }
}