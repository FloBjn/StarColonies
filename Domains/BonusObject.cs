namespace StarColonies.Domains;

public class BonusObject
{
    public string Name { get; set; } = default!;
    public int Price { get; set; }
    public int BonusLevel { get; set; }
    public int BonusForce { get; set; }
    public int BonusStamina { get; set; }
}