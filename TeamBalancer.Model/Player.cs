namespace TeamBalancer.Model;

public class Player : IPlayer
{
    public required string Name { get; set; }
    public double Rating { get; set; }
}
