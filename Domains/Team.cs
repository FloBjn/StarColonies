namespace StarColonies.Domains;

public class Team
{
    public string Name { get; set; }
    public IList<Colon> ColonsTeam { get; set; } = new List<Colon>();
    public IList<BonusObject> TeamBonusObjects { get; set; } = new List<BonusObject>();
    public int LevelMaxAuthorized { get; set; }

    public int GetLevelBonusOfObject()
    {
        int result = 0;
        foreach (var bonusObject in TeamBonusObjects)
        {
            result += bonusObject.BonusLevel;
        }

        return result;
    }

    public int GetForceBonusOfObject()
    {
        int result = 0;
        foreach (var bonusObject in TeamBonusObjects)
        {
            result += bonusObject.BonusForce;
        }

        return result;
    }

    public int GetStaminaBonusOfObject()
    {
        int result = 0;
        foreach (var bonusObject in TeamBonusObjects)
        {
            result += bonusObject.BonusStamina;
        }

        return result;
    }
}