using Aptem.Warehouse.Inventory.Counter.InventoryCounter;

namespace Aptem.Warehouse.Inventory.Counter.Tests;

public class InventoryCounterV2Tests
{
    private readonly InventoryCounterV2 parser;

    public InventoryCounterV2Tests()
    {
        parser = new InventoryCounterV2();
    }

    [Fact]
    public void CanParse_Part2Input_ReturnsTrue()
    {
        const string input = "#p2# 4a 2b 1c";
        Assert.True(parser.CanParse(input));
    }

    [Fact]
    public void CanParse_Part1Input_ReturnsFalse()
    {
        const string input = "aaaa bb c";
        Assert.False(parser.CanParse(input));
    }

    [Fact]
    public void Parse_ValidInput_ReturnsCorrectCounts()
    {
        const string input = "#p2# 4a 2b 1c";
        Dictionary<char, int> expected = new()
        {
            { 'a', 4 },
            { 'b', 2 },
            { 'c', 1 }
        };
        Dictionary<char, int> result = parser.Parse(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Parse_InvalidItemFormat_ThrowsException()
    {
        const string input = "#p2# a4 2b 1c";
        Assert.Throws<InvalidInputFormatException>(() => parser.Parse(input));
    }

    [Fact]
    public void Parse_InputWithDuplicateItems_SumsCounts()
    {
        const string input = "#p2# 4a 2b 1c 3a";
        Dictionary<char, int> expected = new()
        {
            { 'a', 7 },
            { 'b', 2 },
            { 'c', 1 }
        };
        Dictionary<char, int> result = parser.Parse(input);
        Assert.Equal(expected, result);
    }
}