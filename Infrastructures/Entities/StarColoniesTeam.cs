namespace StarColonies.Infrastructures.Entities;

public class StarColoniesTeam
{
    public string TeamId { get; set; }
    public string Name { get; set; }
    public IList<StarColoniesColon> ColonsTeam { get; set; } = new List<StarColoniesColon>();
}