using CsvHelper;
using System.Globalization;
using TeamBalancer.Model;

namespace TeamBalancer.Core;

public static class ReadCSV
{
    public static List<Player> ReadPlayersDatabase(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var players = csv.GetRecords<Player>().ToList();

        foreach (var player in players)
        {
            Console.WriteLine($"# Name: {player.Name};\t Rate: {player.Rating};\t Position: {player.Position}");
        }

        return players;
    }
}