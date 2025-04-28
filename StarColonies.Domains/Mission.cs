using System.ComponentModel.DataAnnotations.Schema;

namespace StarColonies.Domains;

public class Mission
{
    public string MissionId { get; set; }
    public string Name { get; set; }
    public IList<Enemy> MissionEnemies { get; set; }= new List<Enemy>();
    
    public int Level
    {
        get
        {
            return MissionEnemies?.Sum(me => me.Force) ?? 0;
        }
    }

    public bool ChallengesOvercome(Team team)
    {
        int bonusLevel = team.GetLevelBonusOfObject();
        int bonusForce = team.GetForceBonusOfObject();
        int forceEnnemies = MissionEnemies.Sum(me => me.Force);
        int forceTeam = 0;
        foreach (var colon in team.ColonsTeam)
        {
            forceTeam += colon.Force+bonusLevel;
        }
        forceTeam += bonusForce;
        return (forceTeam *2.5)- (forceEnnemies * 1.5)>0;
    }
    public bool TeamIsAlive(Team team)
    {
        int bonusLevel = team.GetLevelBonusOfObject();
        int bonusStamina = team.GetStaminaBonusOfObject();
        int forceEnnemies = MissionEnemies.Sum(me => me.Force);
        int forceTeam = 0;
        foreach (var colon in team.ColonsTeam)
        {
            forceTeam += colon.Force+bonusLevel;
        }
        forceTeam += bonusStamina;
        return (forceTeam *2.5)- (forceEnnemies * 1.5)>0;
    }

    public int GetReward()
    {
        return new Random().Next(1,3)+Level;
    }
}