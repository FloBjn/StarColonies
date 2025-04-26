namespace StarColonies.Infrastructures.Entities;

public class StarColoniesColon
{
    public string ColonId { get; set; }
    public required string Name { get; set; }
    public required int Level { get; set; } = 1;
    public int Force { get; set; }
    public int Stamina { get; set; }
    public int NumberResource { get; set; }
    public required int JobName { get; set; }
    public IList<StarColoniesTeam> Teams { get; set; } = new List<StarColoniesTeam>();
}