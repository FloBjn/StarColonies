namespace StarColonies.Domains;

public class Colon
{ 
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Profession { get; set; } = default!;
        public int Force { get; set; }
        public int Endurance { get; set; }

        public string UserId { get; set; } = default!;
        

}