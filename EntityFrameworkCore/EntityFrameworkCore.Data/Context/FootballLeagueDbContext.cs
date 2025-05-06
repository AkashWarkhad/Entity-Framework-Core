using EntityFrameworkCore.Data.Migrations;
using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace EntityFrameworkCore.Data.Context
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

        public DbSet<League> Leagues { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<TeamsAndLeagueModel> TeamAndLeagueView { get; set; }


        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurtion for SqlServer 
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=FootballLeague_EfCore; Encrypt= False");

            // Configurtion for Sql Lite
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                .UseLazyLoadingProxies()                            // this is load all data at once
                .LogTo(Console.WriteLine, LogLevel.Information)
                //.EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); <- DO not track the query just read it and that sit. Its Quicker
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TeamConfigurationHelper());

            //modelBuilder.ApplyConfiguration(new CoachConfigurationHelper());

            //modelBuilder.ApplyConfiguration(new LeagueConfigurationHelper());

            // OR we can configure it globally like below instade of doing for each.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TeamsAndLeagueModel>().HasNoKey().ToView("vw_TeamAndLeague");
        }
    }
}
