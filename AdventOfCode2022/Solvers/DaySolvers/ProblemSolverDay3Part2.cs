// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay3Part2 : IProblemSolver
{
    private readonly List<BackpackGroup> _input = new();

    public ProblemSolverDay3Part2(IEnumerable<string> input)
    {
        _input = input.Chunk(3).Select(x => new BackpackGroup(x)).ToList();
    }

    public string Solve()
    {
        return $"{SumDuplicatePriority()}";
    }

    private int SumDuplicatePriority()
    {
        return _input
             .Select(rucksack => rucksack.GetDuplicates())
             .Select(duplicates => duplicates.Sum(GetPriorityForLetter))
             .Sum();
    }

    private static int GetPriorityForLetter(char dupe)
    {
        return (dupe % 32) + (char.IsUpper(dupe) ? 26 : 0);
    }
}