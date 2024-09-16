using Aptem.Warehouse.Inventory.Counter.InventoryCounter.Factory;
using Aptem.Warehouse.Inventory.Counter.OutputFormatting;

namespace Aptem.Warehouse.Inventory.Counter;

public sealed class InventoryProcessor(IInventoryCounterFactory parserFactory, IOutputFormatter outputFormatter)
{
    private readonly IInventoryCounterFactory _parserFactory = parserFactory ?? throw new ArgumentNullException(nameof(parserFactory));
    private readonly IOutputFormatter _outputFormatter = outputFormatter ?? throw new ArgumentNullException(nameof(outputFormatter));

    public string ProcessInput(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new InvalidInputFormatException("Input cannot be null or empty.");

        InventoryCounter.IInventoryCounter parser = _parserFactory.GetParser(input);
        Dictionary<char, int> totalCounts = parser.Parse(input);

        return _outputFormatter.FormatData(totalCounts);
    }
}