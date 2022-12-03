// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay3Part1 : IProblemSolver
{
    private readonly List<CompartmentalizedBackpack> _input = new();

    public ProblemSolverDay3Part1(IEnumerable<string> input)
    {
        _input = input.Select(x => new CompartmentalizedBackpack(x)).ToList();
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

    private static int GetPriorityForLetter(KeyValuePair<char, int> dupe)
    {
        return (dupe.Key % 32) + (char.IsUpper(dupe.Key) ? 26 : 0);
    }
}