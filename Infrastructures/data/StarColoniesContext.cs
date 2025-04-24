using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StarColonies.Domains;
using StarColonies.Infrastructures.data.Entities;

namespace StarColonies.Infrastructures.data;

public class StarColoniesContext : IdentityDbContext<StarColoniesUser>
{
    
    public DbSet<Colon> Colons { get; set; }
    public DbSet<Mission> Missions { get; set; }
    
    public DbSet<Defis> Defis { get; set; }

    public StarColoniesContext(DbContextOptions<StarColoniesContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Tu peux ajouter ici tes configurations manuelles (si tu en as)
        // builder.ApplyConfiguration(new TonEntityConfiguration());
        builder.Entity<MissionBete>()
            .HasKey(mb => new { mb.MissionId, BeteId = mb.DefisId });

        builder.Entity<MissionBete>()
            .HasOne(mb => mb.Mission)
            .WithMany(m => m.MissionBetes)
            .HasForeignKey(mb => mb.MissionId);

        builder.Entity<MissionBete>()
            .HasOne(mb => mb.Defis)
            .WithMany(b => b.MissionBetes)
            .HasForeignKey(mb => mb.DefisId);
        
        builder.Entity<Defis>()
            .HasOne(d => d.TypeDefis)
            .WithMany(t => t.Defis)
            .HasForeignKey(d => d.TypeDefisId);
    }
    
}