// See https://aka.ms/new-console-template for more information

using System.Text;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay7Part2 : IProblemSolver
{
    private readonly string _input;
    private const int WindowSize = 14;

    public ProblemSolverDay7Part2(IEnumerable<string> input)
    {
        _input = input.First();
    }

    public string Solve()
    {
        return $"{GetIndexOfFirstMarker()}";
    }

    private int GetIndexOfFirstMarker()
    {
        for (var startIndex = 0; startIndex < _input.Length; startIndex++)
        {
            var window = _input.Substring(startIndex, WindowSize);
            
            if (window.Length == window.Distinct().Count())
                return startIndex + WindowSize;
        }

        return -1;
    }
}