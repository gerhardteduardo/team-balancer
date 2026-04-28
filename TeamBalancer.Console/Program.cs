using TeamBalancer.Core;
using TeamBalancer.Model;

Console.WriteLine("Hello, World!\n");

List<Player> players = LoadPlayers();

foreach (var player in players.OrderByDescending(p => p.Position))
{
    Console.WriteLine($"# Rate: {player.Rating:F1}\t Position: {player.Position}\t Name: {player.Name}");
}

CreateTeams(players);

static List<Player> LoadPlayers()
{
    string path = ".\\Mock\\PlayerStatics.csv";
    List<PlayerStatistics> statistics = ReadCSV.ReadPlayersDatabase(path);

    return [.. statistics
        .GroupBy(p => p.Name)
        .Select(group => CalculatePlayerStats(group))];
}

static Player CalculatePlayerStats(IGrouping<string, PlayerStatistics> playerStats)
{
    string name = playerStats.Key;

    double avgSkill = playerStats.Average(p => p.Skill);
    double avgDefense = playerStats.Average(p => p.Defense);
    double avgAttack = playerStats.Average(p => p.Attack);
    double avgStamina = playerStats.Average(p => p.Stamina);
    double avgTactical = playerStats.Average(p => p.Tactical);

    double rating = (avgSkill + avgDefense + avgAttack + avgStamina + avgTactical) / 5.0;

    EPosition position = (avgAttack > avgDefense) ? EPosition.Attack : EPosition.Defense;

    return new Player(name, rating, position);
}

static void CreateTeams(List<Player> players)
{
    (Team teamA, Team teamB) = Balancer.GreedyAlgorithmWithPlayerPosition(players);

    Console.WriteLine("\nTeam A:");
    teamA.ShowRatingAverage();
    teamA.ShowRatingSum();
    teamA.ShowPlayers();

    Console.WriteLine("\nTeam B:");
    teamB.ShowRatingAverage();
    teamB.ShowRatingSum();
    teamB.ShowPlayers();
}
