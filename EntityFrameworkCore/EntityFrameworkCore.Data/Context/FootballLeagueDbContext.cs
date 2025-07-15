using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EntityFrameworkCore.Data.Context
{
    public class FootballLeagueDbContext : DbContext
    {

        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options) : base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<TeamsAndLeagueModel> TeamAndLeagueView { get; set; }


        public string DbPath { get; private set; } // C:\Users\HP\AppData\Roaming\FootballLeague_EfCore.db


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TeamConfigurationHelper());
            //modelBuilder.ApplyConfiguration(new CoachConfigurationHelper());
            //modelBuilder.ApplyConfiguration(new LeagueConfigurationHelper());

            // OR we can configure it globally like below instade of doing for each.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // This is used to map the view present in the DB.
            modelBuilder.Entity<TeamsAndLeagueModel>().HasNoKey().ToView("vw_TeamAndLeague");

            // This is used to map the function present in the DB.
            modelBuilder.HasDbFunction(typeof(FootballLeagueDbContext).GetMethod(nameof(GetTeamMatch), new[] { typeof(int) }))
                .HasName("GetMatch"); //<- This is the function name from the DB
        }

        // Override the SaveChangesAsync method to handle any custom logic before saving changes.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseDomainModel>().Where(q => q.State == EntityState.Added
            || q.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                entry.Entity.ModifiedBy = "System"; // You can replace this with the actual user context if available

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "New System"; // You can replace this with the actual user context if available
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        // This is used to map the count of records present in the function present in the DB.
        public DateTime GetTeamMatch(int teamId) => throw new NotImplementedException();
    }

    public class FootballLeagueDbContextFactory : IDesignTimeDbContextFactory<FootballLeagueDbContext>
    {
        public FootballLeagueDbContext CreateDbContext(string[] args)
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbFileName = config.GetConnectionString("SqliteDatabaseConnectionString"); // e.g. "FootballLeague_EfCore.db"
            var dbPath = Path.Combine(path, dbFileName); // full path to db file

            // 2️⃣ Build the options EF Core needs
            var optionsBuilder = new DbContextOptionsBuilder<FootballLeagueDbContext>();
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            // 3️⃣ Return a context configured with those options
            return new FootballLeagueDbContext(optionsBuilder.Options);
        }
    }

}
