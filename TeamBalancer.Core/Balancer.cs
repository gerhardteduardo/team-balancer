using TeamBalancer.Model;

namespace TeamBalancer.Core;

public static class Balancer
{
    public static (Team teamA, Team teamB) GreedyAlgorithm(List<Player> players)
    {
        var rnd = new Random();
        var tieredPlayers = players
            .OrderByDescending(p => p.Rating)
            .Chunk(2)
            .SelectMany(pair => pair.OrderBy(x => rnd.Next()))
            .ToList();

        List<Player> playersA = [];
        List<Player> playersB = [];

        double sumA = 0;
        double sumB = 0;

        foreach (var player in tieredPlayers)
        {
            if (sumA <= sumB)
            {
                playersA.Add(player);
                sumA += player.Rating;
            }
            else
            {
                playersB.Add(player);
                sumB += player.Rating;
            }
        }

        Team teamA = new(playersA);
        Team teamB = new(playersB);

        return (teamA, teamB);
    }

    public static (Team teamA, Team teamB) GreedyAlgorithmWithPlayerPosition(List<Player> players)
    {
        List<Player> defensePlayers = [.. players.Where(p => p.Position == EPosition.Defense)];
        List<Player> attackPlayers = [.. players.Where(p => p.Position == EPosition.Attack)];

        (Team backTeamA, Team backTeamB) = GreedyAlgorithm(defensePlayers);
        (Team frontTeamA, Team frontTeamB) = GreedyAlgorithm(attackPlayers);

        Team teamA = new([.. backTeamA.Players, .. frontTeamA.Players]);
        Team teamB = new([.. backTeamB.Players, .. frontTeamB.Players]);

        return (teamA, teamB);
    } 
}
