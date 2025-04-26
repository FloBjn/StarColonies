namespace StarColonies.Domains;

public class Colon
{ 
    public string Name { get; set; } = default!;
    public int Force { get; set; }
    public int Stamina { get; set; }
    public JobName JobName { get; set; }
    public IList<Team> Teams { get; set; } = new List<Team>();
}