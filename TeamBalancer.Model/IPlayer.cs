namespace TeamBalancer.Model;

public interface IPlayer
{
    public string Name { get; set; }
    public double Rating { get; set; }
    public EPosition Position { get; set; }
    //public int? MatchesPlayed { get; set; }
}

public enum EPosition
{
    Goalkeeper,
    Defense,
    Attack,
}