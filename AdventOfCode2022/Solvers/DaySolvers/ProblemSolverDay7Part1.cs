// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Helpers;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay7Part1 : IProblemSolver
{
    private readonly FileSystem _fileSystem;
    
    public ProblemSolverDay7Part1(IEnumerable<string> input)
    {
        _fileSystem = new FileSystem();
        
        var helper = new FileSystemHelper(input.ToList());
        
        helper.BuildFileSystem(_fileSystem.Root, index: 1);
    }
    
    public string Solve()
    {
        return $"{SumOfAllDirsOverSize(100000)}";
    }

    private long SumOfAllDirsOverSize(int maxSize)
    {
        return _fileSystem.GetDirectoriesSizes().Where(s => s <= maxSize).Sum();
    }
}