using System.ComponentModel.DataAnnotations.Schema;

namespace StarColonies.Domains;

public class Mission
{
    public string Name { get; set; }
    public IList<Enemy> MissionEnemies { get; set; }= new List<Enemy>();
    
    public int Level
    {
        get
        {
            return MissionEnemies?.Sum(me => me.Force) ?? 0;
        }
    }
}