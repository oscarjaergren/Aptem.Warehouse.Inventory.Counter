using Aptem.Warehouse.Inventory.Counter.InventoryCounter;
using Aptem.Warehouse.Inventory.Counter.InventoryCounter.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Aptem.Warehouse.Inventory.Counter.Tests;

public class ParserFactoryTests
{
    private readonly InventoryCounterFactory parserFactory;
    private readonly ServiceProvider serviceProvider;

    public ParserFactoryTests()
    {
        ServiceCollection services = new();
        services.AddParsers();
        services.AddSingleton<InventoryCounterFactory, InventoryCounterFactory>();
        serviceProvider = services.BuildServiceProvider();
        parserFactory = serviceProvider.GetRequiredService<InventoryCounterFactory>();
    }

    [Fact]
    public void GetParser_Part1Input_ReturnsPart1Parser()
    {
        const string input = "aaaa bb c";
        IInventoryCounter parser = parserFactory.GetParser(input);
        Assert.IsType<InventoryCounterV1>(parser);
    }

    [Fact]
    public void GetParser_Part2Input_ReturnsPart2Parser()
    {
        const string input = "#p2# 4a 2b 1c";
        IInventoryCounter parser = parserFactory.GetParser(input);
        Assert.IsType<InventoryCounterV2>(parser);
    }

    [Fact]
    public void GetParser_InvalidInput_ThrowsException()
    {
        const string input = "";
        Assert.Throws<InvalidInputFormatException>(() => parserFactory.GetParser(input));
    }
}