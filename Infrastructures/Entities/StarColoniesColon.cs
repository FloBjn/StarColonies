namespace StarColonies.Infrastructures.Entities;

public class StarColoniesColon
{
    public int ColonId { get; set; }
    public required string Name { get; set; } 
    public int Force { get; set; }
    public int Stamina { get; set; }
    public required StarColoniesJob Job { get; set; }
}