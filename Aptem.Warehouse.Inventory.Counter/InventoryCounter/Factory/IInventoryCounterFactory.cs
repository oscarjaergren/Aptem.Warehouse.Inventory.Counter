namespace Aptem.Warehouse.Inventory.Counter.InventoryCounter.Factory;

public interface IInventoryCounterFactory
{
    IInventoryCounter GetParser(string input);
}