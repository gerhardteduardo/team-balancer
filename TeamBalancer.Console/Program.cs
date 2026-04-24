using TeamBalancer.Core;
using TeamBalancer.Model;

Console.WriteLine("Hello, World!\n");

string path = ".\\Mock\\Players.csv";

List<Player> players = ReadCSV.ReadPlayersDatabase(path);

Console.WriteLine("\n# Avarage of players: " + Balancer.AvaragePlayers(players));

(Team teamA, Team teamB) = Balancer.GreedyAlgorithmWithPlayerPosition(players);

Console.WriteLine("\nTeam A:");
teamA.Players.ForEach(p => Console.WriteLine($"# {p.Name}\t *{p.Rating}\t {p.Position}"));

Console.WriteLine("\n# Avarage Team A: " + Balancer.AvarageTeam(teamA));
Console.WriteLine("# Sum Team A: " + Balancer.SumPlayersRating(teamA.Players));

Console.WriteLine("\nTeam B:");
teamB.Players.ForEach(p => Console.WriteLine($"# {p.Name}\t *{p.Rating}\t {p.Position}"));
Console.WriteLine("\n# Avarage Team B: " + Balancer.AvarageTeam(teamB));
Console.WriteLine("# Sum Team B: " + Balancer.SumPlayersRating(teamB.Players));
