// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay7Part1 : IProblemSolver
{
    private readonly FileSystem _fileSystem;

    public ProblemSolverDay7Part1(IEnumerable<string> input)
    {
        _fileSystem = new FileSystem();

        BuildFileSystem(input.ToList());
    }

    private void BuildFileSystem(List<string> input)
    {
        while (input.Any())
        {
            var index = GetIndexOfNextCommandSet(input);

            var commandSet = input.Take(index);
            
            input.RemoveRange(0, index);
        }
        
    }

    private int GetIndexOfNextCommandSet(List<string> input)
    {
        var index = input.FindIndex(x => Regex.IsMatch(x, @"\$ cd \w"));

        return index == -1
            ? input.Count - 1
            : index;
    }

    public string Solve()
    {
        return $"{SumOfAllDirsOverSize(10000)}";
    }

    private int SumOfAllDirsOverSize(int minSize)
    {
        return 1;
    }
}