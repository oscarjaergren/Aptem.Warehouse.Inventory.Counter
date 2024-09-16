namespace Aptem.Warehouse.Inventory.Counter.InventoryCounter;

/// <summary>
/// Parses input in Part 2 format starting with "#p2#" and items as "countItem".
/// </summary>
public sealed class InventoryCounterV2 : IInventoryCounter
{
    public bool CanParse(string input)
    {
        return !string.IsNullOrWhiteSpace(input) && input.TrimStart().StartsWith("#p2#");
    }

    public Dictionary<char, int> Parse(string input)
    {
        string[] items = input[4..].Trim()
                         .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return items.Select(ParseItem)
                    .GroupBy(x => x.Item)
                    .ToDictionary(g => g.Key, g => g.Sum(x => x.Count));
    }

    /// <summary>
    /// Parses individual item strings in the format "countItem".
    /// </summary>
    private static (char Item, int Count) ParseItem(string item)
    {
        int index = item.TakeWhile(char.IsDigit).Count();

        if (index == 0 || index >= item.Length)
        {
            throw new InvalidInputFormatException($"Invalid item format: {item}");
        }

        int count = int.Parse(item[..index]);
        char itemChar = item[index];

        return (itemChar, count);
    }
}
