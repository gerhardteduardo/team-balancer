using CsvHelper;
using System.Globalization;
using TeamBalancer.Model;

namespace TeamBalancer.Core;

public class ReadCSV
{
    public ReadCSV(string path)
    {
        using var reader = new StreamReader(path); 
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var players = csv.GetRecords<Player>().ToList();

        foreach (var player in players)
        {
            Console.WriteLine($"Name: {player.Name}, Rate: {player.Rating}");
        }
    }
}