using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TeamBalancer.Model;

namespace TeamBalancer.Core;

public static class ReadCSV
{
    public static List<Player> ReadPlayersMatching(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var players = csv.GetRecords<Player>().ToList();
        return players;
    }

    public static List<PlayerStatistics> ReadPlayersDatabase(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        csv.Context.RegisterClassMap<PlayerStatisticsMap>();
        csv.Read();

        return [.. csv.GetRecords<PlayerStatistics>()];
    }

    private sealed class PlayerStatisticsMap : ClassMap<PlayerStatistics>
    {
        public PlayerStatisticsMap()
        {
            Map(m => m.Name).Index(1);
            Map(m => m.Skill).Index(2);
            Map(m => m.Defense).Index(3);
            Map(m => m.Attack).Index(4);
            Map(m => m.Stamina).Index(5);
            Map(m => m.Tactical).Index(6);
        }
    }
}