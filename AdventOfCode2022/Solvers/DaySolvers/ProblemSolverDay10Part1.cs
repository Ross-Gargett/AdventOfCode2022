// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay10Part1 : IProblemSolver
{
    private readonly Dictionary<int, int> _cycleResults = new Dictionary<int, int>();
    private readonly int X = 1;
    
    public ProblemSolverDay10Part1(IEnumerable<string> input)
    {
        var cycle = 0;
        
        for (var i = 0; i < input.Count(); i++)
        {
            var splitOp = input.ElementAt(i).Split(" ");

            switch (splitOp[0])
            {
                case "noop":
                    cycle++;
                    _cycleResults.Add(cycle, X);
                    
                    break;
                case "addx":
                    cycle++;
                    _cycleResults.Add(cycle, X);
                    cycle++;
                    _cycleResults.Add(cycle, X);
                    X += int.Parse(splitOp[1]);
                    break;
            }
        }
    }

    public string Solve()
    {
        var signalStrength = CycleSignal(20)
            + CycleSignal(60)
            + CycleSignal(100)
            + CycleSignal(140)
            + CycleSignal(180)
            + CycleSignal(220);
        return $"{signalStrength}";
    }

    private int CycleSignal(int cycleNum)
    {
        Console.WriteLine($"{cycleNum} {_cycleResults[cycleNum]}");
        return _cycleResults[cycleNum] * cycleNum;
    }
}