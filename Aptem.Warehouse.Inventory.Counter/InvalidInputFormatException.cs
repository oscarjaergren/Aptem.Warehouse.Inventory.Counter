namespace Aptem.Warehouse.Inventory.Counter;

public sealed class InvalidInputFormatException : Exception
{
    public InvalidInputFormatException(string message) : base(message)
    {
    }

    public InvalidInputFormatException()
    {
    }

    public InvalidInputFormatException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}