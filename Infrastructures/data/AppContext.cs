using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.data;

public class AppContext : IdentityDbContext<StarColoniesUser>
{
    public DbSet<StarColoniesColon> ScColon { get; set; }
    public DbSet<StarColoniesUser> ScUser { get; set; }
    public DbSet<StarColoniesEnemyType> ScEnemyType { get; set; }
    public DbSet<StarColoniesEnemy> ScEnemy { get; set; }
    public DbSet<StarColoniesMission> ScMission { get; set; }
    public DbSet<StarColoniesTeam> ScTeam { get; set; }
    

    public AppContext(DbContextOptions<AppContext> options)
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
        
        //Définir PK
        builder.Entity<StarColoniesColon>().HasKey(scj => scj.ColonId);
        //PK générée toute seule
        builder.Entity<StarColoniesColon>()
            .Property(e => e.ColonId)
            .ValueGeneratedOnAdd();
        //Définir les associations liées aux teams
        builder.Entity<StarColoniesColon>()
            .HasMany(t => t.Teams)
            .WithMany(c => c.ColonsTeam);
        
        builder.Entity<StarColoniesUser>().HasKey(scu => scu.Id);
        builder.Entity<StarColoniesUser>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        /*builder.Entity<StarColoniesUser>()
            .HasOne(u => u.UserColon);*/
        builder.Entity<StarColoniesUser>()
            .HasOne(u => u.UserColon) // Navigation vers StarColoniesColon
            .WithOne()
            .HasForeignKey<StarColoniesUser>(u => u.ColonId) // ColonId comme clé étrangère
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<StarColoniesEnemyType>().HasKey(sct => sct.EnemyTypeId);
        builder.Entity<StarColoniesEnemyType>()
            .Property(e => e.EnemyTypeId)
            .ValueGeneratedOnAdd();

        builder.Entity<StarColoniesEnemy>().HasKey(sce => sce.EnemyId);
        builder.Entity<StarColoniesEnemy>()
            .Property(e => e.EnemyId)
            .ValueGeneratedOnAdd();
        builder.Entity<StarColoniesEnemy>()
            .HasOne(e => e.EnemyType)
            .WithOne()
            .HasForeignKey<StarColoniesEnemyType>(e => e.EnemyTypeId);
        
        builder.Entity<StarColoniesMission>().HasKey(scm => scm.MissionId);
        builder.Entity<StarColoniesMission>()
            .Property(e => e.MissionId)
            .ValueGeneratedOnAdd();
        builder.Entity<StarColoniesMission>()
            .HasMany(m => m.MissionEnemies);
        
        builder.Entity<StarColoniesTeam>().HasKey(sct => sct.TeamId);
        builder.Entity<StarColoniesTeam>()
            .Property(e => e.TeamId)
            .ValueGeneratedOnAdd();
    }
    
}