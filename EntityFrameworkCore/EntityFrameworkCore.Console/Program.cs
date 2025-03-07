using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

try
{
    var context = new FootballLeagueDbContext();

    // Fetch the Teams data from the DB
    //  SELECT * FROM Teams;

    Console.WriteLine($"Database Path: {context.Database.GetDbConnection().ConnectionString}");

    var teams = context.Teams.ToList();

    foreach (var team in teams)
    {
        Console.WriteLine(team.Name);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Data.ToString() + Environment.NewLine + ex.Message);
}
