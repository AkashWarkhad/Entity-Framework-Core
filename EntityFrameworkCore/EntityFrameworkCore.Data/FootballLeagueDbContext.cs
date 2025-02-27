using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    internal class FootballLeagueDbContext : DbContext
    {     
        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurtion for SqlServer 
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeague_EfCore; Encrypt= False");

            // Configurtion for Sql Lite
            optionsBuilder.UseSqlite($"Data Source=FootballLeague_EfCore.db");
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
                    CreatedAt = new DateTime(2025, 02, 14)
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
