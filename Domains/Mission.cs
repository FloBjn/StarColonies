using System.ComponentModel.DataAnnotations.Schema;

public class Mission
{
    public int Id { get; set; }
    public string Nom { get; set; }
    
    [NotMapped]
    public int Niveau
    {
        get
        {
            return MissionBetes?
                .Sum(mb => mb.Defis.Force) ?? 0;
        }
    }

    public ICollection<MissionBete> MissionBetes { get; set; }= new List<MissionBete>();
}