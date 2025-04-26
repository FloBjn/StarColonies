namespace StarColonies.Infrastructures.Entities;

public class StarColoniesMissionHistory
{
    public string MissionHistoryId { get; set; }
    public string MissionId { get; set; }
    public StarColoniesMission Mission { get; set; }
    public string TeamId { get; set; }
    public StarColoniesTeam Team { get; set; }
    public bool IsSuccess { get; set; }
    
}