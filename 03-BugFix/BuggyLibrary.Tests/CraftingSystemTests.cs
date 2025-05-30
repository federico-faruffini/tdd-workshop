using Xunit;
using BuggyLibrary;

public class CraftingSystemTests
{
    [Fact]
    public void GivenEnoughResourcesForAxe_WhenCraftIsCalled_ThenReturnsTrueAndConsumesResources()
    {
        // Arrange
        var inventory = new Inventory();
        var initialWood = 5;
        var initialStone = 2;
        var expectedWood = 3;
        var expectedStone = 1;
        inventory.AddResource("wood", initialWood);
        inventory.AddResource("stone", initialStone);
        var craftingSystem = new CraftingSystem();

        // Act
        var result = craftingSystem.Craft("axe", inventory);

        // Assert
        Assert.True(result);
        Assert.Equal(expectedWood, inventory.GetAmount("wood"));
        Assert.Equal(expectedStone, inventory.GetAmount("stone"));
    }

    [Fact]
    public void GivenExactResourcesForAxe_WhenCraftIsCalled_ThenReturnsTrueAndInventoryIsEmpty()
    {
        // Arrange
        var inventory = new Inventory();
        var initialWood = 2;
        var initialStone = 1;
        var expectedWood = 0;
        var expectedStone = 0;
        inventory.AddResource("wood", initialWood);
        inventory.AddResource("stone", initialStone);
        var craftingSystem = new CraftingSystem();

        // Act
        var result = craftingSystem.Craft("axe", inventory);

        // Assert
        Assert.True(result);
        Assert.Equal(expectedWood, inventory.GetAmount("wood"));
        Assert.Equal(expectedStone, inventory.GetAmount("stone"));
    }

    [Fact]
    public void GivenUnknownRecipe_WhenCraftIsCalled_ThenReturnsFalseAndInventoryUnchanged()
    {
        // Arrange
        var inventory = new Inventory();
        var initialWood = 10;
        var expectedWood = 10;
        inventory.AddResource("wood", initialWood);
        var craftingSystem = new CraftingSystem();

        // Act
        var result = craftingSystem.Craft("banana", inventory);

        // Assert
        Assert.False(result);
        Assert.Equal(expectedWood, inventory.GetAmount("wood"));
    }

    [Fact]
    public void GivenEnoughMetal_WhenCraftSword_ThenReturnsTrueAndConsumesMetal()
    {
        // Arrange
        var inventory = new Inventory();
        var initialMetal = 3;
        var expectedMetal = 1;
        inventory.AddResource("metal", initialMetal);
        var craftingSystem = new CraftingSystem();

        // Act
        var result = craftingSystem.Craft("sword", inventory);

        // Assert
        Assert.True(result);
        Assert.Equal(expectedMetal, inventory.GetAmount("metal"));
    }

    [Fact]
    public void GivenInventoryWithResources_WhenHasResourceIsCalled_ThenReturnsCorrectResult()
    {
        // Arrange
        var inventory = new Inventory();
        var numberOfGold = 5;
        inventory.AddResource("gold", numberOfGold);

        // Act
        var hasThree = inventory.HasResource("gold", 3);
        var hasSix = inventory.HasResource("gold", 6);

        // Assert
        Assert.True(hasThree);
        Assert.False(hasSix);
    }

    [Fact]
    public void GivenExactAmountOfResource_WhenConsumeIsCalled_ThenResourceIsZero()
    {
        // Arrange
        var inventory = new Inventory();
        var amountToAdd = 2;
        var amountToConsume = 2;
        var expectedRemaining = 0;
        inventory.AddResource("wood", amountToAdd);

        // Act
        inventory.ConsumeResource("wood", amountToConsume);

        // Assert
        Assert.Equal(expectedRemaining, inventory.GetAmount("wood"));
    }

    [Fact]
    public void GivenInsufficientResource_WhenConsumeIsCalled_ThenThrowsException()
    {
        // Arrange
        var inventory = new Inventory();
        var numberOfStones = 1;
        inventory.AddResource("stone", numberOfStones);
        var amountToConsume = 2;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => inventory.ConsumeResource("stone", amountToConsume));
    }

    [Fact]
    public void GivenNotEnoughResourcesForAxe_WhenCraftIsCalled_ThenReturnsFalseAndDoesntConsumeResources()
    {
        // Arrange
        var inventory = new Inventory();
        var initialWood = 2;
        var initialGold = 1;
        inventory.AddResource("wood", initialWood);
        inventory.AddResource("gold", initialGold);
        var craftingSystem = new CraftingSystem();

        // Act
        var result = craftingSystem.Craft("axe", inventory);

        // Assert
        Assert.False(result);
        Assert.Equal(initialWood, inventory.GetAmount("wood"));
        Assert.Equal(initialGold, inventory.GetAmount("gold"));
    }
}
