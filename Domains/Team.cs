namespace StarColonies.Domains;

public class Team
{
    public string Name { get; set; }
    public IList<Colon> ColonsTeam { get; set; } = new List<Colon>();
}