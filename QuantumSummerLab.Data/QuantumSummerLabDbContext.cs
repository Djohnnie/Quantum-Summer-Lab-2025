using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuantumSummerLab.Data.Model;

namespace QuantumSummerLab.Data;

public class QuantumSummerLabDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Score> Scores { get; set; }

    public QuantumSummerLabDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetValue<string>("CONNECTION_STRING"));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Challenge>(entityBuilder =>
        {
            entityBuilder.ToTable("CHALLENGES");
            entityBuilder.HasKey(x => x.Id).IsClustered(false);
            entityBuilder.Property(x => x.SysId).ValueGeneratedOnAdd();
            entityBuilder.HasIndex(x => x.SysId).IsClustered();
            entityBuilder.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Team>(entityBuilder =>
        {
            entityBuilder.ToTable("TEAMS");
            entityBuilder.HasKey(x => x.Id).IsClustered(false);
            entityBuilder.Property(x => x.SysId).ValueGeneratedOnAdd();
            entityBuilder.HasIndex(x => x.SysId).IsClustered();
            entityBuilder.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Score>(entityBuilder =>
        {
            entityBuilder.ToTable("SCORES");
            entityBuilder.HasKey(x => x.Id).IsClustered(false);
            entityBuilder.Property(x => x.SysId).ValueGeneratedOnAdd();
            entityBuilder.HasIndex(x => x.SysId).IsClustered();
        });

        base.OnModelCreating(modelBuilder);
    }
}