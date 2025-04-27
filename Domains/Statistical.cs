namespace StarColonies.Domains;

public class Statistical
{
    public IList<MissionHistory> MissionHistories { get; set; } = new List<MissionHistory>();
    
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
        return numberOfTimeSucceed *100/ numberOfTimePlayed;
    }
}