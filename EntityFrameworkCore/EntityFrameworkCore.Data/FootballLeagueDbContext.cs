using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurtion for SqlServer 
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeague_EfCore; Encrypt= False");

            // Configurtion for Sql Lite
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); <- DO not track the query just read it and that sit. Its Quicker
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "CSK Team",
                    CreatedAt = new DateTime(2025, 02, 12)
                },
                new Team
                {
                    TeamId = 2,
                    Name = "MI Team",
                    CreatedAt = new DateTime(2025, 02, 13)
                },
                new Team
                {
                    TeamId = 3,
                    Name = "KKR Team",
                    CreatedAt = new DateTime(2025, 05, 14)
                },
                new Team
                {
                    TeamId = 4,
                    Name = "CSK",
                    CreatedAt = new DateTime(2025, 04, 12)
                },
                new Team
                {
                    TeamId = 5,
                    Name = "CSK Team B",
                    CreatedAt = new DateTime(2025, 03, 12)
                });

            modelBuilder.Entity<Coach>().HasData(new Coach 
            {
                Id = 4,
                Name = "MK Sir",
                CreatedAt = new DateTime(2025, 02, 13)
            });
        }
    }
}
