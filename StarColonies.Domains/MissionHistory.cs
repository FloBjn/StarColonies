namespace StarColonies.Domains;

public class MissionHistory
{
    public string MissionHistoryId { get; set; }
    public string MissionId { get; set; }
    public Mission Mission { get; set; }
    public string TeamId { get; set; }
    public Team Team { get; set; }
    public bool IsSuccess { get; set; }
}