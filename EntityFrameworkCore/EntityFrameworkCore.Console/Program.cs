using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

using var context = new FootballLeagueDbContext();

// Fetch All Teams data from the DB
await GetAllTeams();

// Fetch Teams data from the DB By Id
await GetTeamById();

// Get data By Filter
await GetTeamByFilter();

// Get the Matching data using delimeter %
await GetAllTeamsQuerySyntax();

// Aggregate Methods
await AggrigationMethods();

// Grouping & Aggrigation together
await GroupingMethod();

// OrderBy Method
await OrderByMethod();


async Task OrderByMethod()
{
    // Assending Order
    var orderItemsInAscending = await context.Teams
        .OrderBy(x=> x.Name)
        .ToListAsync();
    PrintData(orderItemsInAscending, "Assending Order");

    // Descending Order
    var orderItemsInDescending = await context.Teams
        .OrderByDescending(x => x.Name)
        .ToListAsync();
    PrintData(orderItemsInDescending, "Descending Order");
}

async Task GroupingMethod()
{
    //SELECT YEAR(CreatedAt) AS CreatedAtYear, TeamId, Name
    //FROM Teams
    //WHERE Name LIKE '%CSK%'
    //AND TeamId >= 2
    //GROUP BY CreatedAtYear;


    var groupedTeam = await context.Teams
    .Where(x => x.Name.Contains("CSK") && x.TeamId >= 2) // Filter before grouping
    .GroupBy(x => x.CreatedAt.Year)
    .ToListAsync(); // Grouping is now safe

    foreach (var group in groupedTeam)
    {
        var year = group.Key;
        Console.WriteLine($"###### Year: {year}"); // Print the year

        foreach (var team in group) // Iterate over group
        {
            Console.WriteLine($"- {team.Name} (ID: {team.TeamId})");
        }
    }
}

async Task AggrigationMethods()
{
    // Aggregate Mthods

    // COUNT
    var noOfTeamMembers = await context.Teams.CountAsync();
    PrintNumbers(noOfTeamMembers, "Total number of team members: ");

    var NoOfTeamMemversWithConditions = await context.Teams.CountAsync(x=> x.TeamId >= 3);
    PrintNumbers(NoOfTeamMemversWithConditions, "Total number of team members with Conditions: ");

    // MAX
    var maxTeam = await context.Teams.MaxAsync(x=> x.TeamId);
    PrintNumbers(maxTeam, "Max: ");

    // MIN
    var minTeam = await context.Teams.MinAsync(x => x.TeamId);
    PrintNumbers(minTeam, "MIN: ");

    // AVG
    var avgTeam = await context.Teams.AverageAsync(x => x.TeamId);
    PrintNumbers((int)avgTeam, "AVG: ");

    // SUM
    var sumTeam = await context.Teams.SumAsync(x => x.TeamId);
    PrintNumbers(sumTeam, "SUM: ");

}

void PrintNumbers(int count, string msg)
{
    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + msg + count);
}

async Task GetTeamByFilter()
{
    Console.Write("---------------------------------- Enter a Team name ---------------------------------- :");
    
    var readData = Console.ReadLine();

    var data = await context.Teams.Where(x => x.Name == readData).ToListAsync();
    PrintData(data, "Exact match");

    // To search matching data in the table using Contains
    var patialMatches = await context.Teams.Where(x=> x.Name.Contains(readData)).ToListAsync();
    PrintData(patialMatches, "Contains Function");

    // To Search matching data in the table using EF core Like function
    var likeData = await context.Teams.Where(x=> EF.Functions.Like(x.Name, $"%{readData}%")).ToListAsync();
    PrintData(likeData, "Like Function");
}

async Task GetAllTeamsQuerySyntax()
{
    var input = "CSK";

    var teams = await (from team in context.Teams
                where EF.Functions.Like(team.Name, $"%{input}%")
                select team).ToListAsync();
    PrintData(teams, "Select Query using %");
}

void PrintData(List<Team> data, string who = "")
{
    foreach (var team in data)
    {
        Console.WriteLine($"{who} ################# {team.Name}, {team.CreatedAt}, {team.TeamId} #################");
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