namespace StarColonies.Domains;

public class Colon
{ 
    public string ColonId { get; set; }
    public string Name { get; set; } = default!;
    public int Level { get; set; } = 1;
    public int Force { get; set; }
    public int Stamina { get; set; }
    public int NumberResource { get; set; }

    public void AddResource(int amount)
    {
        NumberResource += amount;
    }

    public bool CanAfford(int amount)
    {
        return amount < NumberResource;
    }
    public void SubtractResource(int amount)
    {
        NumberResource -= amount;
    }
    public JobName JobName { get; set; }
    public IList<Team> Teams { get; set; } = new List<Team>();
}