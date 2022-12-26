namespace AdventOfCode2022.Models;

public class Monkey
{
    public Monkey(IEnumerable<int> startingItems,
                  string operation, int divisibilityTest,
                  int trueTarget, int falseTarget)
    {
        Items = startingItems.ToList();
        Operation = operation;
        DivisibilityTest = divisibilityTest;

        Inspections = 0;
        TrueTarget = trueTarget;
        FalseTarget = falseTarget;
    }

    public List<int> Items { get; set; }
    public string Operation { get; set; }
    public int DivisibilityTest { get; set; }
    public int Inspections { get; set; }
    public int TrueTarget { get; set; }
    public int FalseTarget { get; set; }

    public List<MonkeyThrow> InspectItems()
    {
        var throws = Items.Select(PerformOperation)
            .Select(newWorry => newWorry % DivisibilityTest == 0
                ? InitializeTrueThrow(newWorry)
                : InitializeFalseThrow(newWorry))
            .ToList();

        Items.Clear();
        
        return throws;
    }

    private MonkeyThrow InitializeTrueThrow(int item)
    {
        return new MonkeyThrow
        {
            Item = item,
            Target = TrueTarget
        };
    }

    private MonkeyThrow InitializeFalseThrow(int item)
    {
        return new MonkeyThrow
        {
            Item = item,
            Target = FalseTarget
        };
    }

    private int PerformOperation(int item)
    {
        var operationParts = Operation.Split(" ");

        operationParts = operationParts.Select((x, i) =>
            string.Equals(x, "old", StringComparison.OrdinalIgnoreCase)
                ? $"{item}" 
                : x).ToArray();

        var result = int.Parse(operationParts[0]);
        var op = operationParts[1];

        Inspections++;
        
        return op switch
        {
            "+" => (int)Math.Floor((result + int.Parse(operationParts[2])) / 3.0),
            "*" => (int)Math.Floor((result * int.Parse(operationParts[2])) / 3.0),
            _ => 0
        };
    }

    public void AddItem(int item)
    {
        Items.Add(item);
    }
}

public class MonkeyThrow
{
    public int Item { get; set; }
    public int Target { get; set; }
}