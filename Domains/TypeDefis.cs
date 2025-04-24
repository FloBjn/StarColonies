public class TypeDefis
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;

    public ICollection<Defis> Defis { get; set; } = new List<Defis>();
}