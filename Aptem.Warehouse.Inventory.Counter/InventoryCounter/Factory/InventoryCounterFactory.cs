namespace Aptem.Warehouse.Inventory.Counter.InventoryCounter.Factory;

/// <summary>
///     Factory class responsible for selecting the appropriate parser.
/// </summary>
public sealed class InventoryCounterFactory : IInventoryCounterFactory
{
    private readonly List<IInventoryCounter> parsers;

    public InventoryCounterFactory()
    {
        parsers =
            [
                new InventoryCounterV1(),
                new InventoryCounterV2()
            ];
    }

    /// <summary>
    ///     Returns the appropriate parser for the given input.
    /// </summary>
    public IInventoryCounter GetParser(string input)
    {
        foreach (IInventoryCounter parser in parsers)
        {
            if (parser.CanParse(input))
            {
                return parser;
            }
        }
        throw new InvalidInputFormatException("No suitable parser found for the input.");
    }
}