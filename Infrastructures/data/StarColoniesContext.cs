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
            entity.HasKey(scu => scu.Id);
            
            entity.Property(e => e.Id)
                        .ValueGeneratedOnAdd();
            
            entity.HasOne(u => u.UserColon)
                .WithOne()
                .HasForeignKey<StarColoniesUser>(e => e.ColonId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        

        builder.Entity<StarColoniesEnemy>(entity =>
        {
            entity.HasKey(sce => sce.EnemyId);
            
            entity.Property(e => e.EnemyId)
                .ValueGeneratedOnAdd();
        });

        builder.Entity<StarColoniesMission>(entity =>
        {
            entity.HasKey(scj => scj.MissionId);
            
            entity.Property(e => e.MissionId)
                .ValueGeneratedOnAdd();
            
            entity.HasMany(m => m.MissionEnemies)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ScMissionEnemies",
                    r => r.HasOne<StarColoniesEnemy>().WithMany().HasForeignKey("EnemyId"),
                    l => l.HasOne<StarColoniesMission>().WithMany().HasForeignKey("MissionId"),
                    je =>
                    {
                        je.HasKey("MissionId", "EnemyId");
                        je.ToTable("ScMissionEnemies");
                    });
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
         
        AddInitialData(builder);
    }

    private void AddInitialData(ModelBuilder builder)
    {
        builder.Entity<StarColoniesColon>().HasData(new List<StarColoniesColon>
        {
             new StarColoniesColon {ColonId = Guid.NewGuid().ToString(), Name = "Alex Striker", Level = 1, Force = 5, Stamina = 2, NumberResource = 0, JobName = 1},
             new StarColoniesColon {ColonId = Guid.NewGuid().ToString(), Name = "Mira Nova", Level = 1, Force = 3, Stamina = 4, NumberResource = 0, JobName = 0},
             new StarColoniesColon {ColonId = Guid.NewGuid().ToString(), Name = "Elara Starfinder", Level = 1, Force = 2, Stamina = 5, NumberResource = 0, JobName = 3},
             new StarColoniesColon {ColonId = Guid.NewGuid().ToString(), Name = "Jason Blades", Level = 1, Force = 4, Stamina = 3, NumberResource = 0, JobName = 2},

        });
        
        var droneId = Guid.NewGuid().ToString();
        var anomalieId = Guid.NewGuid().ToString();
        var cryptoideId = Guid.NewGuid().ToString();
        var spectreId = Guid.NewGuid().ToString();
        var nanobotId = Guid.NewGuid().ToString();
        var predateurId = Guid.NewGuid().ToString();
        var chimereId = Guid.NewGuid().ToString();
        var titanId = Guid.NewGuid().ToString();
        var entiteId = Guid.NewGuid().ToString();
        var mutantId = Guid.NewGuid().ToString();
        var leviathanId = Guid.NewGuid().ToString();
        var hegemonId = Guid.NewGuid().ToString();
        var combatDroneId = Guid.NewGuid().ToString();
        
        builder.Entity<StarColoniesEnemy>().HasData(new List<StarColoniesEnemy>
        {
            new StarColoniesEnemy {EnemyId = droneId, Name = "Drone", Force = 2, Stamina = 2, EnemyTypeNameId = 0},
            new StarColoniesEnemy {EnemyId = anomalieId, Name = "Anomalie", Force = 1, Stamina = 3, EnemyTypeNameId = 1},
            new StarColoniesEnemy {EnemyId = cryptoideId, Name = "Cryptoïde", Force = 4, Stamina = 12, EnemyTypeNameId = 2},
            new StarColoniesEnemy {EnemyId = spectreId, Name = "Spectre", Force = 7, Stamina = 1, EnemyTypeNameId = 3},
            new StarColoniesEnemy {EnemyId = nanobotId, Name = "Nanobot", Force = 1, Stamina = 2, EnemyTypeNameId = 0},
            new StarColoniesEnemy {EnemyId = predateurId, Name = "Prédateur", Force = 4, Stamina = 3, EnemyTypeNameId = 4},
            new StarColoniesEnemy {EnemyId = chimereId, Name = "Chimère", Force = 4, Stamina = 4, EnemyTypeNameId = 5},
            new StarColoniesEnemy {EnemyId = titanId, Name = "Titan", Force = 5, Stamina = 3, EnemyTypeNameId = 2},
            new StarColoniesEnemy {EnemyId = entiteId, Name = "Entité", Force = 5, Stamina = 11, EnemyTypeNameId = 3},
            new StarColoniesEnemy {EnemyId = mutantId, Name = "Mutant", Force = 2, Stamina = 4, EnemyTypeNameId = 6},
            new StarColoniesEnemy {EnemyId = leviathanId, Name = "Leviathan", Force = 9, Stamina = 7, EnemyTypeNameId = 2},
            new StarColoniesEnemy {EnemyId = hegemonId, Name = "Hégémon", Force = 20, Stamina = 20, EnemyTypeNameId = 2},
            new StarColoniesEnemy {EnemyId = combatDroneId, Name = "Drone de combat", Force = 20, Stamina = 15, EnemyTypeNameId = 0},
        });

        
        builder.Entity<StarColoniesBonusObject>().HasData(new List<StarColoniesBonusObject>
        {
            new StarColoniesBonusObject {BonusObjectId = Guid.NewGuid().ToString(), Name = "Potion Mystérieuse", Price = 30, BonusLevel = 1, BonusForce = 0, BonusStamina = 0},
            new StarColoniesBonusObject {BonusObjectId = Guid.NewGuid().ToString(), Name = "Barre protéinée", Price = 5, BonusLevel = 0, BonusForce = 1, BonusStamina = 0},
            new StarColoniesBonusObject {BonusObjectId = Guid.NewGuid().ToString(), Name = "Boisson énergétique", Price = 5, BonusLevel = 0, BonusForce = 0, BonusStamina = 1},

        });
        
        
        var baseMission = Guid.NewGuid().ToString();
        var testMission = Guid.NewGuid().ToString();
        
        builder.Entity<StarColoniesMission>().HasData(new List<StarColoniesMission>
                {
                    new StarColoniesMission {MissionId = baseMission,Name = "Exploration de la base abandonnée"},
                    new StarColoniesMission {MissionId = testMission,Name = "Test"}
                });
        
        
        builder.Entity("ScMissionEnemies", entity =>
        {
            entity.HasData(
                new { MissionId = baseMission, EnemyId = anomalieId },
                new { MissionId = baseMission, EnemyId = predateurId },
                new { MissionId = testMission, EnemyId = predateurId },
                new { MissionId = testMission, EnemyId = titanId }
            );
        });
    }
    
}