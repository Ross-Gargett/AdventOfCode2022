// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay11Part2 : IProblemSolver
{
    private readonly Dictionary<int, int> _cycleResults = new Dictionary<int, int>();
    private int X = 2;
    
    private const int CrtRowLength = 40;
    
    public ProblemSolverDay11Part2(IEnumerable<string> input)
    {
        HandleCrtOutput(input.ToArray());
    }

    private void HandleCrtOutput(string[] input)
    {
        var cycle = 1;
        
        foreach (var operation in input)
        {
            var splitOp = operation.Split(" ");

            switch (splitOp[0])
            {
                case "noop":
                    PrintPixel(cycle);
                    IncrementCycle(ref cycle);
                    break;
                case "addx":
                    PrintPixel(cycle);
                    IncrementCycle(ref cycle);
                    PrintPixel(cycle);
                    X += int.Parse(splitOp[1]);
                    IncrementCycle(ref cycle);
                    break;
            }
        }
    }

    private static void IncrementCycle(ref int cycle)
    {
        cycle++;

        if (cycle > CrtRowLength)
            cycle = 1;
    }

    private void PrintPixel(int cycle)
    {
        Console.Write(
            cycle >= X - 1 && cycle <= X + 1 
            ? "#" 
            : ".");
        
        if (cycle == CrtRowLength) 
            Console.WriteLine();
    }

    public string Solve()
    {
        return $"";
    }
}