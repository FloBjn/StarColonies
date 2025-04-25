using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.data;

public class StarColoniesContext(DbContextOptions<StarColoniesContext> options)
    : IdentityDbContext<StarColoniesUser>(options)
{
    
    public DbSet<StarColoniesColon> ScColon { get; set; }
    public DbSet<StarColoniesUser> ScUser { get; set; }
    public DbSet<StarColoniesMission> ScMission { get; set; }
    public DbSet<StarColoniesEnemy> ScEnemy { get; set; }
    public DbSet<StarColoniesEnemyType> ScEnemyType { get; set; }
    public DbSet<StarColoniesJob> ScJob { get; set; }
    
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
    
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<StarColoniesUser>()
            .HasOne(u => u.UserColon)
            .WithOne()
            .HasForeignKey<StarColoniesColon>(c => c.ColonId);
        
        
        /*
        // Tu peux ajouter ici tes configurations manuelles (si tu en as)
        // builder.ApplyConfiguration(new TonEntityConfiguration());
        builder.Entity<MissionEnemies>()
            .HasKey(me => new { me.MissionId, BeteId = me.DefisId });

        builder.Entity<MissionEnemies>()
            .HasOne(mb => mb.Mission)
            .WithMany(m => m.MissionBetes)
            .HasForeignKey(mb => mb.MissionId);

        builder.Entity<MissionEnemies>()
            .HasOne(mb => mb.Defis)
            .WithMany(b => b.MissionBetes)
            .HasForeignKey(mb => mb.DefisId);
        
        builder.Entity<Mission>()
            .HasOne(d => d.TypeDefis)
            .WithMany(t => t.Defis)
            .HasForeignKey(d => d.TypeDefisId);
            
        */
    }
    
}