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

        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Data Source=localhost\\MSSQLSERVER01; Initial Catalog=FootballLeague_EfCore; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
