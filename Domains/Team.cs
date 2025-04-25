namespace StarColonies.Domains;

public class Team
{
    public string Name { get; set; }
    public ICollection<Colon> ColonsTeam { get; set; } = new List<Colon>();
}