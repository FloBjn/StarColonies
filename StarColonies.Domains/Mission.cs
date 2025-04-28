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

    public bool IsChallengesOvercomed(Team team)
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
        
        var rndFactorEnemy = new Random().NextDouble()*2 +1;
        var rdFactorTeam = new Random().NextDouble()*3 + 1;
        
        return (forceTeam * rdFactorTeam) - (forceEnnemies * rndFactorEnemy) > 0;
    }
    public bool IsTeamAlive(Team team)
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

        var rndFactorEnemy = new Random().NextDouble()+1;
        var rdFactorTeam = new Random().NextDouble()*3 + 1;

        return (forceTeam * rdFactorTeam)- (forceEnnemies * rndFactorEnemy) > 0;
    }

    public int GetReward()
    {
        return new Random().Next(1,3)+Level;
    }
}