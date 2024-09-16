namespace Aptem.Warehouse.Inventory.Counter.OutputFormatting;

public interface IOutputFormatter
{
    string FormatData(Dictionary<char, int> totalCounts);
}

public sealed class OutputFormatter : IOutputFormatter
{
    public string FormatData(Dictionary<char, int> totalCounts)
    {
        return string.Join(" ", totalCounts.OrderBy(kvp => char.ToLower(kvp.Key))
                                           .Select(kvp => $"{kvp.Value}{kvp.Key}"));
    }
}