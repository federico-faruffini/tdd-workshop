namespace BuggyLibrary;

public class Inventory
{
    private Dictionary<string, int> resources = new();

    public void AddResource(string name, int amount)
    {
        if (!resources.ContainsKey(name))
        {
            resources[name] = 0;
        }

        resources[name] += amount;
    }

    public bool HasResource(string name, int amount)
    {
        return resources.ContainsKey(name) && resources[name] >= amount;
    }

    public void ConsumeResource(string name, int amount)
    {
        if (!HasResource(name, amount))
        {
            throw new InvalidOperationException("Not enough resources");
        }
        
        resources[name] -= amount;
    }

    public int GetAmount(string name) => resources.ContainsKey(name) ? resources[name] : 0;
}