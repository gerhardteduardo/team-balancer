using TeamBalancer.Model;

namespace TeamBalancer.Core;

public static class Balancer
{
    public static double SumPlayersRating(List<Player> players)
    {
        return players.Sum(p => p.Rating);
    }

    public static double AvaragePlayers(List<Player> players)
    {
        return players.Average(p => p.Rating);
    }

    public static double AvarageTeam(Team team)
    {
        return team.Players.Average(p => p.Rating);
    }

    public static (Team teamA, Team teamB) GreedyAlgorithm(List<Player> players)
    {
        players = [.. players.OrderByDescending(p => p.Rating)];

        Team teamA = new()
        {
            Players = [.. players.Where((p, i) => i % 2 == 0)]
        }; 
        
        Team teamB = new()
        {
            Players = [.. players.Where((p, i) => i % 2 != 0)]
        };

        return (teamA, teamB);
    }
}
