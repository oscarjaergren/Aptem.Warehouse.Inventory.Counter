using Microsoft.Extensions.DependencyInjection;

namespace Aptem.Warehouse.Inventory.Counter.Tests;

public class InventoryProcessorIntegrationTests
{
    private readonly InventoryProcessor _inventoryProcessor;

    public InventoryProcessorIntegrationTests()
    {
        ServiceCollection services = new();
        services.AddParsers();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        _inventoryProcessor = serviceProvider.GetRequiredService<InventoryProcessor>();
    }

    [Theory]
    [InlineData("aaaa bb c", "4a 2b 1c")]
    [InlineData("#p2# 4a 2b 1c", "4a 2b 1c")]
    [InlineData("#p2# 3a 2b 4a", "7a 2b")]
    [InlineData("a b c a b c", "2a 2b 2c")]
    [InlineData("#p2# 1a 1b 1c 1a", "2a 1b 1c")]
    public void ProcessInput_ValidInputs_ReturnsExpectedOutputs(string input, string expectedOutput)
    {
        string output = _inventoryProcessor.ProcessInput(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void ProcessInput_InvalidInput_ThrowsInvalidInputFormatException()
    {
        const string invalidInput = "4593490-590-3590-112";
        Assert.Throws<InvalidInputFormatException>(() => _inventoryProcessor.ProcessInput(invalidInput));
    }

    [Fact]
    public void ProcessInput_NullOrEmptyInput_ThrowsInvalidInputFormatException()
    {
        Assert.Throws<InvalidInputFormatException>(() => _inventoryProcessor.ProcessInput(null));
        Assert.Throws<InvalidInputFormatException>(() => _inventoryProcessor.ProcessInput(string.Empty));
    }

    [Fact]
    public void ProcessInput_Part2InvalidItemFormat_ThrowsInvalidInputFormatException()
    {
        const string invalidInput = "#p2# a4 2b 1c";
        Assert.Throws<InvalidInputFormatException>(() => _inventoryProcessor.ProcessInput(invalidInput));
    }

    [Fact]
    public void ProcessInput_Part1InputWithNonLetters_IgnoresNonLetters()
    {
        const string input = "a1a2a3 bb$% c!";
        const string expectedOutput = "3a 2b 1c";
        string output = _inventoryProcessor.ProcessInput(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void ProcessInput_Part2InputWithExtraSpaces_ReturnsCorrectOutput()
    {
        const string input = "#p2#   4a   2b    1c ";
        const string expectedOutput = "4a 2b 1c";
        string output = _inventoryProcessor.ProcessInput(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void ProcessInput_CaseInsensitiveProcessing_ReturnsCorrectOutput()
    {
        const string input = "AAaa BB cc";
        const string expectedOutput = "2A 2a 2B 2c";
        string output = _inventoryProcessor.ProcessInput(input);
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void ProcessInput_LargeQuantities_ReturnsCorrectOutput()
    {
        const string input = "#p2# 1000a 2000b 3000c";
        const string expectedOutput = "1000a 2000b 3000c";
        string output = _inventoryProcessor.ProcessInput(input);
        Assert.Equal(expectedOutput, output);
    }
}