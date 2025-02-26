using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    internal class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        // Configurtion for SqlServer 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootbalLeague_EfCore; Encrypt= False");
        //}

        // Configuration for Sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=FootbalLeague_EfCore.db");
        }
    }
}
