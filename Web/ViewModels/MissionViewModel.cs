namespace StarColonies.Web.ViewModels;

public class MissionViewModel
{
    public int Id { get; set; }
    public string Nom { get; set; }= string.Empty;
    public int Niveau { get; set; }
    public List<DefisViewModel> Defis { get; set; } = new();
}