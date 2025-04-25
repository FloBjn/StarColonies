using System.ComponentModel.DataAnnotations.Schema;

namespace StarColonies.Domains;

public class Mission
{
    public string Name { get; set; }
    public ICollection<Enemy> MissionEnemies { get; set; }= new List<Enemy>();
    
    //[NotMapped]
    public int Level
    {
        get
        {
            return MissionEnemies?.Sum(mb => mb.Force) ?? 0;
        }
    }
}