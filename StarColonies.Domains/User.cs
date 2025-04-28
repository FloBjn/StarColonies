namespace StarColonies.Domains;

public class User
{
    public string Id { get; set; }
    public string? Email { get; set; }
    public string Name { get; set; }
    public string? Avatar { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsAdmin { get; set; }

    public string ColonId {get; set;}
    public Colon UserColon { get; set; } = default!;
}