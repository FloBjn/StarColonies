namespace StarColonies.Infrastructures.Entities;

public class StarColoniesTeam
{
    public string TeamId { get; set; }
    public string Name { get; set; }
    public IList<StarColoniesColon> ColonsTeam { get; set; } = new List<StarColoniesColon>();
    public IList<StarColoniesBonusObject> TeamBonusObjects { get; set; } = new List<StarColoniesBonusObject>();
    //0 veut dire que la team n'a pas de limitation
    public required int LevelMaxAuthorized { get; set; }
}