namespace StarColonies.Domains;

public class Enemy
{
    public string Name { get; set; }
    public int Force { get; set; }
    public int Stamina { get; set; }
    public EnemyTypeName EnemyType { get; set; } 
}