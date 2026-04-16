namespace TeamBalancer.Model;

public interface IPlayer
{
    public string Name { get; set; }
    public double Rating { get; set; }
    //public string? Position { get; set; }
    //public int? MatchesPlayed { get; set; }
}