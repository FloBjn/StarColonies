using Microsoft.AspNetCore.Identity;

namespace StarColonies.Infrastructures.Entities;

public class StarColoniesUser : IdentityUser
{
    public int UserId { get; set; }
    public string? Avatar { get; set; }
    public required DateOnly BirthDate { get; set; }
    
    public required StarColoniesColon UserColon { get; set; }
}