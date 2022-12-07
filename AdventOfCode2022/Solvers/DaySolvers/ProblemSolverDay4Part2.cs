// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay4Part2 : IProblemSolver
{
    private readonly List<(List<int>, List<int>)> _input = new();

    public ProblemSolverDay4Part2(IEnumerable<string> input)
    {
        _input = input.Select(x =>
        {
            var cleanupPairs = x.Split(',');
            
            return 
                (
                    GenerateCharList(cleanupPairs[0]), 
                    GenerateCharList(cleanupPairs[1])
                );
        }).ToList();
    }

    private static List<int> GenerateCharList(string cleanupRange)
    {
        var range = cleanupRange.Split('-');
        
        var start = int.Parse($"{range[0]}");
        var length = (int.Parse($"{range[1]}") - start) + 1;
        return Enumerable.Range(start, length).ToList();
    }

    public string Solve()
    {
        return $"{CountCompleteOverlap()}";
    }

    private int CountCompleteOverlap()
    {
        return _input.Sum(DetermineOverlap);
    }

    private int DetermineOverlap((List<int>, List<int>) arg)
    {
        var overlapLength = arg.Item1.Intersect(arg.Item2).Count();
        
        return overlapLength > 0
            ? 1
            : 0;
    }
}