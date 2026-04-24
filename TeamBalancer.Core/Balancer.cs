using System.Numerics;
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
        var sortedPlayers = players.OrderByDescending(p => p.Rating).ToList();

        Team teamA = new() { Players = [] };
        Team teamB = new() { Players = [] };

        double sumA = 0;
        double sumB = 0;

        foreach (var player in sortedPlayers)
        {
            if (sumA <= sumB)
            {
                teamA.Players.Add(player);
                sumA += player.Rating;
            }
            else
            {
                teamB.Players.Add(player);
                sumB += player.Rating;
            }
        }
        return (teamA, teamB);
    }
}
