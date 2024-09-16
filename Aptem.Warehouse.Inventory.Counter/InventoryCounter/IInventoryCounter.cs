namespace Aptem.Warehouse.Inventory.Counter.InventoryCounter;

public interface IInventoryCounter
{
    /// <summary>
    /// Determines if the parser can handle the given input.
    /// </summary>
    bool CanParse(string input);

    Dictionary<char, int> Parse(string input);
}