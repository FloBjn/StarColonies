namespace StarColonies.Infrastructures.Entities;

public class StarColoniesEnemy
{
    public string EnemyId { get; set; }
    public required string Name { get; set; }
    public required int Force { get; set; }
    public required int Stamina { get; set; }
    public required int EnemyTypeNameId { get; set; }
}