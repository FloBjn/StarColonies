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
            optionsBuilder.UseSqlServer("Server=192.168.132.200,11433;Database=Q220191;User Id=Q220191;Password=0191;TrustServerCertificate=True;MultipleActiveResultSets=True");

            return new StarColoniesContext(optionsBuilder.Options);
        }
    }
}