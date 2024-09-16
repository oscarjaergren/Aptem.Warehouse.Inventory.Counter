using Aptem.Warehouse.Inventory.Counter.InventoryCounter;
using Aptem.Warehouse.Inventory.Counter.InventoryCounter.Factory;
using Aptem.Warehouse.Inventory.Counter.OutputFormatting;
using Microsoft.Extensions.DependencyInjection;

namespace Aptem.Warehouse.Inventory.Counter;

public static class DependencyInjectionExtensions
{
    //These should in ideal scenario be split up various different ones so we don't have to add ones we don't always need
    public static IServiceCollection AddParsers(this IServiceCollection services)
    {
        services.AddSingleton<IInventoryCounterFactory, InventoryCounterFactory>();
        services.AddTransient<IInventoryCounter, InventoryCounterV1>();
        services.AddTransient<IInventoryCounter, InventoryCounterV2>();
        services.AddSingleton<IOutputFormatter, OutputFormatter>();
        services.AddTransient<InventoryProcessor>();

        return services;
    }
}
