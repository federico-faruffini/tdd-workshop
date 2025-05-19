namespace BuggyLibrary;

public class CraftingSystem
{
    private Dictionary<string, Dictionary<string, int>> recipes = new();

    public CraftingSystem()
    {
        recipes["axe"] = new Dictionary<string, int>
        {
            { "wood", 2 },
            { "stone", 1 }
        };

        recipes["sword"] = new Dictionary<string, int>
        {
            { "metal", 2 }
        };
    }

    public bool Craft(string itemName, Inventory inventory)
    {
        if (!recipes.ContainsKey(itemName))
        {
            return false;
        }

        var recipe = recipes[itemName];

        foreach (var (resource, amount) in recipe)
        {
            if (!inventory.HasResource(resource, amount))
            {
                return false;
            }
            
            inventory.ConsumeResource(resource, amount); 
        }

        return true;
    }
}
