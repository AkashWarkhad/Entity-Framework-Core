using EntityFrameworkCore.Data.Context;
using EntityFrameworkCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

// Note Just press INSERT Key when new data overrides existing ////////////////////////////

using var context = new FootballLeagueDbContext();

//await AddRelatedData(context);

await GetTeamAndViewData();

// Eager Loading to load the data
await EagerLoading();

// Explicitly Loading
await ExplicitlyLoading();

// Lazy Loading
await LazyLoading();

// Fetch All Teams data from the DB
await GetAllData();

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

// Add the Coaches in the table
await AddData();

// Update the existing record
await UpdateData();

// Delete the record
await DeleteData();


async Task GetTeamAndViewData()
{
    var data = await context.TeamAndLeagueView.ToListAsync();

    foreach (var item in data)
    {
        Console.WriteLine($"###### Team Name :{item.Name} | League Name {item.LeagueName}");
    }
}

async Task EagerLoading()
{
    // When Needed then only Eager Load the data from the table
    var leagues = await context.Leagues
        .Include(x=> x.Teams)           // Load Team
        .ThenInclude(x=> x.Coach)       // Load Coach
        .ToListAsync();

    Console.WriteLine("################## Eager Loading ##################");

    foreach (var league in leagues)
    {
        Console.WriteLine($"###### Leauge : # {league.Name} #");
        var cnt = 1;
        foreach (var team in league.Teams)
        {
            Console.WriteLine($"{cnt++}. Team Name : {team.Name}. |  Coach Name : {team.Coach.Name}.");
        }
        Console.WriteLine(Environment.NewLine );
    }
}

async Task ExplicitlyLoading()
{
    var leagues = await context.Leagues.FindAsync(4);

    if (leagues == null) return;

    await context.Entry(leagues)
        .Collection(x=> x.Teams)      // Load Team here we can load only 1 level of data.
        .LoadAsync();

    Console.WriteLine("################## Explicitly Loading ##################");

    Console.WriteLine($"###### Leauge : # {leagues.Name} #");
    
    foreach (var team in leagues.Teams)
    {
        Console.WriteLine($"1. Team Name : {team.Name}.");
    }
    Console.WriteLine(Environment.NewLine);
}

async Task LazyLoading()
{
    var league = await context.Leagues.FindAsync(4);

    if (league == null) return;

    Console.WriteLine("################## Lazy Loading ##################");
    Console.WriteLine($"###### Leauge : # {league.Name} #");
    var cnt = 1;
    foreach (var team in league.Teams)
    {
        Console.WriteLine($"{cnt++}. Team Name : {team.Name}. |  Coach Name : {team.Coach.Name}.");
    }
    Console.WriteLine(Environment.NewLine);
}

async Task DeleteData()
{
    PrintCoachesData(await context.Coaches.ToListAsync());

    Console.WriteLine("Do you want to Delete the above inserted data?");
    var yes = Console.ReadLine() ?? "N";

    if (yes.ToString().Equals("y", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("################## Insert a Coach Id to be Delete : ");
        int id = Convert.ToInt32(Console.ReadLine());

        var coach = await context.Coaches
            // .AsNoTracking()  <- if its marked a no tracker then we cannot save the changes in the DB
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coach != null)
        {
            Console.WriteLine($"################## Coach {coach.Id}.{coach.Name} is deleted,");

            // Here we have to change the Entry State to make in modified entry state
            //context.Entry(coach).State = EntityState.Deleted;
            context.Coaches.Remove(coach);
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("Invalid data, Data not found!!");
        }
    }
}

async Task UpdateData()
{
    PrintCoachesData(await context.Coaches.ToListAsync());

    Console.WriteLine("Do you want to update the above inserted data?");
    var yes = Console.ReadLine();

    if (yes.ToString().Equals("y", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("################## Insert a Coach Id to update : ");
        int id = Convert.ToInt32(Console.ReadLine());

        var coach = await context.Coaches
            // .AsNoTracking()  <- if its marked a no tracker then we cannot save the changes in the DB
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coach != null)
        {
            Console.WriteLine("################## Enter new Coach name : ");
            var data = Console.ReadLine();
            // Update data
            coach.Name = data;
            coach.CreatedAt = DateTime.Now;

            // Here we have to change the Entry State to make in modified entry state
            //context.Entry(coach).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        else
        {
            Console.WriteLine("Invalid data, Data not found!!");
        }
    }

}

async Task AddData()
{
    Console.WriteLine("########################   You want insert a new coaches? Y/N");
    var yes = Console.ReadLine();
    var newCoaches = new List<Coach>();

    while (yes.ToString().Equals("y", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("######################## Enter a coache name :");
        var insertedData = Console.ReadLine();

        var newCoach = new Coach
        {
            Name = insertedData,
            CreatedAt = DateTime.Now
        };

        newCoaches.Add(newCoach);

        Console.WriteLine("Do you want insert a new coache again? Y/N");
        yes = Console.ReadLine();

        if (yes.ToString().Equals("n", StringComparison.OrdinalIgnoreCase))
        {
            await context.AddRangeAsync(newCoaches);
            await context.SaveChangesAsync();
            Console.WriteLine("############## Data inserted successfully! ########################");
        }
    }

    // Add the new Coaches in the table
    PrintCoachesData(newCoaches);
}

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
            TeamId = x.Id
        }).ToListAsync();

    foreach (var team in data)
    {
        Console.WriteLine($"Projection Data : {team.Name} & {team.TeamId}");
    }
}

async Task SkipAndTake()
{
    var pageNo = 0;
    var recordCount = 3;

    var data = await context.Teams.Skip(pageNo * recordCount).Take(recordCount).ToListAsync();
    PrintData(data, "Skip & Take");
}

async Task OrderByMethod()
{
    // Assending Order
    var orderItemsInAscending = await context.Teams
        .OrderBy(x => x.Name)
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
    .Where(x => x.Name.Contains("CSK") && x.Id >= 2) // Filter before grouping
    .GroupBy(x => x.CreatedAt.Year)
    .ToListAsync(); // Grouping is now safe

    foreach (var group in groupedTeam)
    {
        var year = group.Key;
        Console.WriteLine($"###### Year: {year}"); // Print the year

        foreach (var team in group) // Iterate over group
        {
            Console.WriteLine($"- {team.Name} (ID: {team.Id})");
        }
    }
}

async Task AggrigationMethods()
{
    // Aggregate Mthods

    // COUNT
    var noOfTeamMembers = await context.Teams.CountAsync();
    PrintNumbers(noOfTeamMembers, "Total number of team members: ");

    var NoOfTeamMemversWithConditions = await context.Teams.CountAsync(x => x.Id >= 3);
    PrintNumbers(NoOfTeamMemversWithConditions, "Total number of team members with Conditions: ");

    // MAX
    var maxTeam = await context.Teams.MaxAsync(x => x.Id);
    PrintNumbers(maxTeam, "Max: ");

    // MIN
    var minTeam = await context.Teams.MinAsync(x => x.Id);
    PrintNumbers(minTeam, "MIN: ");

    // AVG
    var avgTeam = await context.Teams.AverageAsync(x => x.Id);
    PrintNumbers((int)avgTeam, "AVG: ");

    // SUM
    var sumTeam = await context.Teams.SumAsync(x => x.Id);
    PrintNumbers(sumTeam, "SUM: ");

}

void PrintNumbers(int count, string msg)
{
    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@" + msg + count);
}

async Task GetTeamByFilter()
{
    Console.Write("---------------------------------- Enter a Team name ---------------------------------- :");

    var readData = Console.ReadLine() ?? "";

    var data = await context.Teams.Where(x => x.Name == readData).ToListAsync();
    PrintData(data, "Exact match");

    // To search matching data in the table using Contains
    var patialMatches = await context.Teams.Where(x => x.Name != null && x.Name.Contains(readData)).ToListAsync();
    PrintData(patialMatches, "Contains Function");

    // To Search matching data in the table using EF core Like function
    var likeData = await context.Teams.Where(x => EF.Functions.Like(x.Name, $"%{readData}%")).ToListAsync();
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
    Console.WriteLine(Environment.NewLine);
    foreach (var team in data)
    {
        Console.WriteLine($"{who} ################# {team.Id}. {team.Name}, {team.CreatedAt}, {team.CreatedBy}, {team.ModifiedDate}, {team.ModifiedBy}.   #################");
    }
    Console.Write("---------------------------------- Data ^:");
}

void PrintCoachesData(List<Coach> data, string who = "")
{
    Console.WriteLine(Environment.NewLine);
    foreach (var coach in data)
    {
        Console.WriteLine($"{who} ################# {coach.Id}. {coach.Name}, {coach.CreatedAt},  {coach.CreatedBy}, {coach.ModifiedDate}, {coach.ModifiedBy}. #################");
    }
    Console.Write("---------------------------------- Data ^:");
}

async Task GetTeamById()
{
    // Using First Here Below 1, 2 will gives exception when no data found.
    var t1 = context.Teams.First(x => x.Id == 1);
    var t2 = await context.Teams.FirstAsync(x => x.Id == 1);
    var t3 = context.Teams.FirstOrDefault(x => x.Id == 1);
    var t4 = await context.Teams.FirstOrDefaultAsync(x => x.Id == 1);

    // Using Single Here Below 5, 6 will gives exception when no data found.
    var t5 = context.Teams.Single(x => x.Id == 1);
    var t6 = await context.Teams.SingleAsync(x => x.Id == 1);
    var t7 = context.Teams.SingleOrDefault(x => x.Id == 1);
    var t8 = await context.Teams.SingleOrDefaultAsync(x => x.Id == 1);

    // Using Find No one gives you exception when n
    var t9 = context.Teams.Find(100);
    var t10 = await context.Teams.FindAsync(1);
}

async Task GetAllData()
{
    try
    {
        var teams = await context.Teams.ToListAsync();
        PrintData(teams, "All Teams Data :");

        var coaches = await context.Coaches.ToListAsync();
        PrintCoachesData(coaches, "All Coaches Data :");

        var leagues = await context.Leagues.ToListAsync();
        PrintLeaguesData(leagues, "All Leagues Data :");

        var matches = await context.Matches.ToListAsync();
        PrintMatchesData(matches, "All Matches Data :");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Data.ToString() + Environment.NewLine + ex.Message);
    }
}

void PrintLeaguesData(List<League> leagues, string? mesg)
{
    Console.WriteLine(Environment.NewLine);
    foreach (var league in leagues)
    {
        Console.WriteLine($"{mesg} ################# {league.Id}. {league.Name}, {league.CreatedAt},  {league.CreatedBy}, {league.ModifiedDate}, {league.ModifiedBy}. #################");
    }
    Console.Write("---------------------------------- Data ^:");
}

void PrintMatchesData(List<Match> matches, string? mesg)
{
    Console.WriteLine(Environment.NewLine);
    foreach (var match in matches)
    {
        Console.WriteLine($"{mesg} ################# {match.Id}. {match.HomeTeamId}, {match.AwayTeamId}, {match.TicketPrice}, {match.CreatedAt},  {match.CreatedBy}, {match.ModifiedDate} ,  {match.ModifiedBy}. #################");
    }
    Console.Write("---------------------------------- Data ^:");
}

static async Task AddRelatedData(FootballLeagueDbContext context)
{
    var team = new Team        // Add 2 related records at same time
    {
        Name = "Kings India",
        Coach = new Coach
        {
            Name = "KI Coach"
        }
    };

    var newLeague = new League() // Create a League with all new related record + existing one
    {
        Id = 4,
        Name = "Tata Premiere League",
        Teams = new List<Team>
                        {
                            new Team()
                            {
                                Name = "Royal Challanger Banglore",
                                Coach = new Coach()
                                {
                                    Name = "RCB Coach"
                                }
                            },
                            new Team()
                            {
                                Name = "fattyabad Team",
                                Coach = new Coach
                                {
                                    Name = "Jonathan Roniyo"
                                }
                            }
                        }
    };

    await context.Teams.AddAsync(team);
    await context.Leagues.AddAsync(newLeague);
    await context.SaveChangesAsync();
}