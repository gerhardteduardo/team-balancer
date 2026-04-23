namespace TeamBalancer.Model;

public class Team : ITeam
{
    public required List<Player> Players { get; set; }
}
