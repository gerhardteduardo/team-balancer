namespace TeamBalancer.Model;

public class Team(List<Player> players)
{
    public List<Player> Players { get; } = players;

    public void ShowPlayers()
    {
        Players.ForEach(p => Console.WriteLine($"# {p.Position}\t *{p.Rating:F1}\t {p.Name}"));
    }

    public void ShowRatingAverage()
    {
        double average = RatingAverage();
        Console.WriteLine($"# Rating Average: *{average:F1}");
    }

    public void ShowRatingSum()
    {
        double sum = RatingSum();
        Console.WriteLine($"# Rating Sum: *{sum:F1}");
    }

    private double RatingAverage()
    {
        return Players.Average(p => p.Rating);
    }

    private double RatingSum()
    {
        return Players.Sum(p => p.Rating);
    }
}
