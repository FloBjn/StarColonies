namespace StarColonies.Domains;

public class Colon
{ 
    public string Name { get; set; } = default!;
    public int Force { get; set; }
    public int Stamina { get; set; }
    public Job Job { get; set; } = default!;
    
}