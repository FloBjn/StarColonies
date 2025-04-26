namespace StarColonies.Domains;

public class User
{
    public string? Avatar { get; set; }
    public DateOnly BirthDate { get; set; }
    public Colon UserColon { get; set; } = default!;
}