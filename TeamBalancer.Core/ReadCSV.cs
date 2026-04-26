using CsvHelper;
using CsvHelper.Configuration;
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

    public static List<PlayerStatistics> ReadPlayersRatingDatabase(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        var players = csv.GetRecords<PlayerStatistics>().ToList();

        //foreach (var player in players)
        //{
        //    Console.WriteLine($"# Defense: {player.Defense};\t Attack: {player.Attack};\t Name: {player.Name}");
        //}

        return players;
    }
}