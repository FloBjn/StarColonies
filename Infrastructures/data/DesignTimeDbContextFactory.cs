using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StarColonies.Infrastructures.data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StarColoniesContext>
    {
        public StarColoniesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StarColoniesContext>();

            // Utiliser la chaîne de connexion définie dans appsettings.json ou une chaîne de connexion hardcodée
            optionsBuilder.UseSqlServer("Server=192.168.132.200,11433;Database=Q230243;User Id=Q230243;Password=0243;TrustServerCertificate=True;MultipleActiveResultSets=True");

            return new StarColoniesContext(optionsBuilder.Options);
        }
    }
}