namespace StarColonies.Domains;

public class Statistics
{
    public IList<MissionHistory> MissionHistories { get; set; }
    public IList<Team> Teams { get; set; }
    public double? GetWinningpercentageOfMissions(Mission mission)
    {
        int numberOfTimePlayed = 0;
        int numberOfTimeSucceed = 0;
        foreach (var missions in MissionHistories.Where(missions => missions.Mission == mission))
        {
            numberOfTimePlayed++;
            if (missions.IsSuccess)
            {
                numberOfTimeSucceed++;
            }
        }

        if (numberOfTimePlayed == 0)
        {
            return null;
        }
        Console.WriteLine("succes :" + numberOfTimeSucceed);
        Console.WriteLine("timeplayed :" + numberOfTimePlayed);
        return numberOfTimeSucceed *100/ numberOfTimePlayed;
    }

    public List<KeyValuePair<string, int>> GetAllOfFame()
    {
        Dictionary<string, int> classement = new Dictionary<string, int>();
        
        foreach (var team in Teams)
        {
            classement.Add(team.Name, 0);
        }
        
        foreach (var missionHistory in MissionHistories)
        {
            if (missionHistory.IsSuccess && classement.ContainsKey(missionHistory.Team.Name))
            {
                classement[missionHistory.Team.Name] += missionHistory.Mission.Level;
            }
        }
        return classement.OrderByDescending(e => e.Value).ToList();;
    }
}