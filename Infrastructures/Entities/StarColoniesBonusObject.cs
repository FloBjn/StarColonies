namespace StarColonies.Infrastructures.Entities;

public class StarColoniesBonusObject
{
    public string BonusObjectId { get; set; }
    public required string Name { get; set; }
    public required int Price { get; set; }
    public int BonusLevel { get; set; }
    public int BonusForce { get; set; }
    public int BonusStamina { get; set; }
}