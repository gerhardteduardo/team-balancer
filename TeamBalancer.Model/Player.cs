namespace TeamBalancer.Model;

public class Player(string name, double rating, EPosition position)
{
    public string Name { get; set; } = name;
    public double Rating { get; set; } = rating;
    public EPosition Position { get; set; } = position;
}