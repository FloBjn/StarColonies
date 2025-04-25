namespace StarColonies.Infrastructures.Entities;

public class StarColoniesEnemy
{
    public int EnemyId { get; set; }
    public required string Name { get; set; }
    public required StarColoniesEnemyType EnemyType { get; set; }
}