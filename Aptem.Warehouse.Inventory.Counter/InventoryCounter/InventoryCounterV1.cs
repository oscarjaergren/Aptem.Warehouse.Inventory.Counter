namespace Aptem.Warehouse.Inventory.Counter.InventoryCounter;

public sealed class InventoryCounterV1 : IInventoryCounter
{
    public bool CanParse(string input)
    {
        return !string.IsNullOrWhiteSpace(input) &&
               input.Any(char.IsLetter) &&
               !input.TrimStart().StartsWith('#');
    }

    public Dictionary<char, int> Parse(string input)
    {
        return input.Where(char.IsLetter)
                    .GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());
    }
}