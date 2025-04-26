namespace StarColonies.Infrastructures.Entities;

public class StarColoniesEnemy
{
    public string EnemyId { get; set; }
    public required string Name { get; set; }
    public string EnemyTypeId { get; set; }
    public required int EnemyType { get; set; }
}