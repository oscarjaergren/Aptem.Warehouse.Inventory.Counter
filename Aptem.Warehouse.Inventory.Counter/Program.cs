using Aptem.Warehouse.Inventory.Counter;
using Microsoft.Extensions.DependencyInjection;

ServiceProvider serviceProvider = ConfigureServices();
InventoryProcessor inventoryProcessor = serviceProvider.GetRequiredService<InventoryProcessor>();

while (true)
{
    Console.WriteLine("Enter warehouse inventory message (or 'exit' to quit):");
    string? input = Console.ReadLine();

    if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exiting the application. Goodbye!");
        break;
    }

    try
    {
        string output = inventoryProcessor.ProcessInput(input);
        Console.WriteLine(output);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
}

static ServiceProvider ConfigureServices()
{
    ServiceCollection services = new();
    services.AddParsers();
    return services.BuildServiceProvider();
}