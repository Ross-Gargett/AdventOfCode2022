namespace AdventOfCode2022.Models;

public class Monkey
{
    public Monkey(IEnumerable<long> startingItems,
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

    public List<long> Items { get; set; }
    public string Operation { get; set; }
    public int DivisibilityTest { get; set; }
    public int Inspections { get; set; }
    public int TrueTarget { get; set; }
    public int FalseTarget { get; set; }

    public List<MonkeyThrow> InspectItems(double factor, MonkeyPart part)
    {
        var throws = Items
            .Select(x => PerformOperation(x, 
                                             part, 
                                             factor))
            .Select(newWorry => newWorry % DivisibilityTest == 0
                ? InitializeTrueThrow(newWorry)
                : InitializeFalseThrow(newWorry))
            .ToList();

        Items.Clear();
        
        return throws;
    }

    private MonkeyThrow InitializeTrueThrow(long item)
    {
        return new MonkeyThrow
        {
            Item = item,
            Target = TrueTarget
        };
    }

    private MonkeyThrow InitializeFalseThrow(long item)
    {
        return new MonkeyThrow
        {
            Item = item,
            Target = FalseTarget
        };
    }

    private long PerformOperation(long item, 
                                 MonkeyPart part, 
                                 double factor = 0)
    {
        var operationParts = Operation.Split(" ");

        operationParts = operationParts.Select((x, i) =>
            string.Equals(x, "old", StringComparison.OrdinalIgnoreCase)
                ? $"{item}" 
                : x).ToArray();

        var result = long.Parse(operationParts[0]);
        var op = operationParts[1];

        Inspections++;
        
        var operationResult = op switch
        {
            "+" => result + long.Parse(operationParts[2]),
            "*" => result * long.Parse(operationParts[2]),
            _ => 0
        };

        if (part == MonkeyPart.Part1)
        {
            return (long)Math.Floor(operationResult / 3.0);
        }
        
        return (long)Math.Floor(operationResult % factor);
    }

    public void AddItem(long item)
    {
        Items.Add(item);
    }
}

public class MonkeyThrow
{
    public long Item { get; set; }
    public int Target { get; set; }
}