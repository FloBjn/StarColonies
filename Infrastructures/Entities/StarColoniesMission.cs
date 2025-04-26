namespace StarColonies.Infrastructures.Entities;

public class StarColoniesMission
{
    public string MissionId { get; set; }
    public string Name { get; set; }
    public IList<StarColoniesEnemy> MissionEnemies { get; set; } = new List<StarColoniesEnemy>();
}