using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityFrameworkCore.Data.Context
{
    public class FootballTemporalDbContext : DbContext
    {
        public FootballTemporalDbContext()
        {
            
        }

        public DbSet<Team> Teams2 { get; set; }

        public DbSet<Coach> Coaches2 { get; set; }

        public DbSet<League> Leagues2 { get; set; }

        public DbSet<Match> Matches2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeague_EfCore; Encrypt=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
