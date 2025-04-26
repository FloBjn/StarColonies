using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StarColonies.Domains;
using StarColonies.Infrastructures.Entities;

namespace StarColonies.Infrastructures.data;

public class StarColoniesContext : IdentityDbContext<StarColoniesUser>
{
    public DbSet<StarColoniesColon> ScColon { get; set; }
    public DbSet<StarColoniesUser> ScUser { get; set; }
    public DbSet<StarColoniesEnemyType> ScEnemyType { get; set; }
    public DbSet<StarColoniesEnemy> ScEnemy { get; set; }
    public DbSet<StarColoniesMission> ScMission { get; set; }
    public DbSet<StarColoniesTeam> ScTeam { get; set; }
    public DbSet<StarColoniesBonusObject> ScBonusObject { get; set; }
    public DbSet<StarColoniesMissionHistory> ScMissionHistory { get; set; }
    

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

        builder.Entity<StarColoniesColon>(entity =>
        {
            //Définir PK
            entity.HasKey(scj => scj.ColonId);
            //PK générée toute seule
            entity.Property(e => e.ColonId)
                .ValueGeneratedOnAdd();
            //Définir les associations
            entity.HasMany(t => t.Teams)
                .WithMany(c => c.ColonsTeam);
        });
        

        builder.Entity<StarColoniesUser>(entity =>
        {
            entity.HasKey(scu => scu.UserId);
            
            entity.Property(e => e.UserId)
                        .ValueGeneratedOnAdd();
            
            entity.HasOne(u => u.UserColon)
                .WithOne()
                .HasForeignKey<StarColoniesUser>(e => e.ColonId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        

        builder.Entity<StarColoniesEnemyType>(entity =>
        {
            entity.HasKey(sct => sct.EnemyTypeId);
            
            entity.Property(e => e.EnemyTypeId)
                .ValueGeneratedOnAdd();
        });
        

        builder.Entity<StarColoniesEnemy>(entity =>
        {
            entity.HasKey(sce => sce.EnemyId);
            
            entity.Property(e => e.EnemyId)
                .ValueGeneratedOnAdd();
            
            entity.HasOne(e => e.EnemyType)
                .WithOne()
                .HasForeignKey<StarColoniesEnemyType>(e => e.EnemyTypeId);
        });
        

        builder.Entity<StarColoniesMission>(entity =>
        {
            entity.HasKey(scj => scj.MissionId);
            
            entity.Property(e => e.MissionId)
                .ValueGeneratedOnAdd();
            
            entity.HasMany(m => m.MissionEnemies);
        });
        
        
        builder.Entity<StarColoniesTeam>(entity =>
        {
            entity.HasKey(sct => sct.TeamId);
            
            entity.Property(e => e.TeamId)
                .ValueGeneratedOnAdd();
        });
        

        builder.Entity<StarColoniesBonusObject>(entity =>
        {
            entity.HasKey(scbo => scbo.BonusObjectId);
            
            entity.Property(scbo => scbo.BonusObjectId)
                .ValueGeneratedOnAdd();
        });
        
        
        builder.Entity<StarColoniesMissionHistory>(entity =>
        {
            entity.HasKey(e => e.MissionHistoryId);
            
            entity.Property(e => e.MissionHistoryId)
                .ValueGeneratedOnAdd();

            entity.HasOne(e => e.Mission)
                .WithMany()
                .HasForeignKey(e => e.MissionId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Team)
                .WithMany()
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
    }
    
}