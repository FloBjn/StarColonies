namespace StarColonies.Domains;

public class BonusObject
{
    public string BonusObjectId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Price { get; set; }
    public int BonusLevel { get; set; }
    public int BonusForce { get; set; }
    public int BonusStamina { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj is not BonusObject other)
            return false;

        return BonusObjectId == other.BonusObjectId;
    }
    public override int GetHashCode()
    {
        return BonusObjectId?.GetHashCode() ?? 0;
    }
}