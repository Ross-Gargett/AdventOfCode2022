// See https://aka.ms/new-console-template for more information

using System.Text;
using AdventOfCode2022.Helpers;
using AdventOfCode2022.Models;
using Directory = AdventOfCode2022.Models.Directory;
using File = AdventOfCode2022.Models.File;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay7Part2 : IProblemSolver
{
    private readonly FileSystem _fileSystem;
    private readonly List<string> _input;
    
    public ProblemSolverDay7Part2(IEnumerable<string> input)
    {
        _fileSystem = new FileSystem();

        var helper = new FileSystemHelper(input.ToList());
        
        helper.BuildFileSystem(_fileSystem.Root, index: 1);
    }
    
    public string Solve()
    {
        return $"{GetSmallestDirForUpdate()}";
    }

    private long GetSmallestDirForUpdate()
    {
        var dirSizes = _fileSystem.GetDirectoriesSizes();

        var freeSpace = 70000000 - _fileSystem.TotalSize;

        var neededSpace = 30000000 - freeSpace;
        
        return dirSizes.Where(s => s > neededSpace).Order().First();
    }
}