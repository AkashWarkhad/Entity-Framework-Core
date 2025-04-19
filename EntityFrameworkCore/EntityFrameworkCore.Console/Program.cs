using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Note Just press INSERT Key that sit  /////////////////////////////////////////////

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

// Skip the pageNo & take a records.
await SkipAndTake();

// Retrieve the required projection from the data
await GetTeamsProjection();

// No Tracking vs tracking Query
await GetDataWithNoTracking();

// IQueryable VS ListType
await GetDataWithQueryableAndInMemoryListType();

async Task GetDataWithQueryableAndInMemoryListType()
{
    // Queryable object : here it just SQL Query generation. No execusion
    IQueryable<Team> teamsQueryable = context.Teams.AsQueryable();

    // Add more filters on queryable to addon the SQL Query.
    teamsQueryable = teamsQueryable.Where(x => x.Name.Contains("CSK"));

    // Execute the genearted SQL Query on the DB by list type
    var finalData = await teamsQueryable.ToListAsync();

    PrintData(finalData, "Print as a Queryable data :");
}

async Task GetDataWithNoTracking()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();
    var data = await context.Teams
        .AsNoTracking()
        .ToListAsync();
   
    Console.WriteLine($"{data.Count} Data Retrieved in: {stopwatch.ElapsedMilliseconds} milliSecond with No tracking");

    var stopwatch2 = new Stopwatch();
    stopwatch2.Start();
    var data2 = await context.Teams
        .AsTracking()
        .ToListAsync();

    Console.WriteLine($"{data2.Count} Data Retrieved in: {stopwatch2.ElapsedMilliseconds} milliSecond with tracking");

    Console.WriteLine($"Time Difference between 2 tracking was {stopwatch2.ElapsedMilliseconds - stopwatch.ElapsedMilliseconds}");
}

async Task GetTeamsProjection()
{
    var data = await context.Teams
        .Select(x => new TeamInfo()
        {
            Name = x.Name,
            TeamId = x.TeamId
        }).ToListAsync();

    foreach(var team in data)
    {
        Console.WriteLine($"Projection Data : {team.Name} & {team.TeamId}");
    }
}

async Task SkipAndTake()
{
    var pageNo = 0;
    var recordCount = 3;
    var next = true;

    var data = await context.Teams.Skip(pageNo * recordCount).Take(recordCount).ToListAsync();
    PrintData(data, "Skip & Take");
}

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