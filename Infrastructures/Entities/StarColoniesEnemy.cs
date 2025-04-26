namespace StarColonies.Infrastructures.Entities;

public class StarColoniesEnemy
{
    public string EnemyId { get; set; }
    public required string Name { get; set; }
    public required StarColoniesEnemyType EnemyType { get; set; }
}