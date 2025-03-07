using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

using var context = new FootballLeagueDbContext();

// Fetch All Teams data from the DB
await GetAllTeams();

// Fetch Teams data from the DB By Id
await GetTeamById();

// Get data By Filter
await GetTeamByFilter();


async Task GetTeamByFilter()
{
    Console.Write("---------------------------------- Enter a Team name :");
    var readData = Console.ReadLine();

    var data = await context.Teams.Where(x => x.Name == readData).ToListAsync();
    foreach (var team in data)
    {
        Console.WriteLine($"{team.Name}, {team.CreatedAt}, {team.TeamId}");
    }
    Console.Write("---------------------------------- Data ^:");
}

async Task GetTeamById()
{
    // Using First Here Below 1, 2 will gives exception when no data found.
    var t1 = context.Teams.First(x => x.TeamId == 1);
    var t2 = await context.Teams.FirstAsync(x => x.TeamId == 1);
    var t3 = context.Teams.FirstOrDefault(x => x.TeamId == 1);
    var t4 = await context.Teams.FirstOrDefaultAsync(x=> x.TeamId == 1);

    // Using Single Here Below 5, 6 will gives exception when no data found.
    var t5 = context.Teams.Single(x => x.TeamId == 1);
    var t6 = await context.Teams.SingleAsync(x => x.TeamId == 1);
    var t7 = context.Teams.SingleOrDefault(x => x.TeamId == 1);
    var t8 = await context.Teams.SingleOrDefaultAsync(x => x.TeamId == 1);

    // Using Find No one gives you exception when n
    var t9 = context.Teams.Find(100);
    var t10 = await context.Teams.FindAsync(1);
}

async Task GetAllTeams()
{
    try
    {
        var teams = await context.Teams.ToListAsync();

        foreach (var team in teams)
        {
            Console.WriteLine(team.Name);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Data.ToString() + Environment.NewLine + ex.Message);
    }
}