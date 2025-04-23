namespace StarColonies.Infrastructures.data.Entities;
using Microsoft.AspNetCore.Identity;

public class StarColoniesUser : IdentityUser
{
    public required string FirstName { get; set; }
    
    public string? Avatar { get; set; }
    
    public required DateOnly BirthDate { get; set; }
}