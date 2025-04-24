public class Defis
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Force { get; set; }
    public int Endurance { get; set; }
    
    public int TypeDefisId { get; set; }
    public TypeDefis TypeDefis { get; set; } = null!;

    public ICollection<MissionBete> MissionBetes { get; set; }
}