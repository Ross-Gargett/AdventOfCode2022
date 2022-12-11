// See https://aka.ms/new-console-template for more information

using AdventOfCode2022.Models;
using Directory = AdventOfCode2022.Models.Directory;
using File = AdventOfCode2022.Models.File;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay7Part1 : IProblemSolver
{
    private readonly FileSystem _fileSystem;
    private readonly List<string> _input;
    
    public ProblemSolverDay7Part1(IEnumerable<string> input)
    {
        _fileSystem = new FileSystem();
        _input = input.ToList();

        BuildFileSystem(_fileSystem.Root, index: 1);
    }

    private void BuildFileSystem(Directory activeNode, 
                                 int index)
    {
        if (_input.Count == index)
            return;

        if (_input[index].StartsWith("$ cd"))
        {
            HandleChangeDirectory(activeNode, index);
        }
        
        if (_input[index].StartsWith("$ ls"))
        {
            index++;
            HandleAddDirectoryContents(activeNode, ref index);
        }
    }

    private void HandleChangeDirectory(Directory activeNode, int index)
    {
        var directory = _input[index].Replace("$ cd ", string.Empty);

        if (directory == "..")
            BuildFileSystem(activeNode.Parent, index + 1);
        else
            BuildFileSystem(activeNode.Directories
                .First(d => d.Name.Equals(directory, StringComparison.OrdinalIgnoreCase)), index + 1);
    }

    private void HandleAddDirectoryContents(Directory activeNode, ref int index)
    {
        while (_input.Count > index && !_input[index].StartsWith("$"))
        {
            if (_input[index].StartsWith("dir"))
            {
                AddNewDirectory(activeNode, _input[index]);
                index++;
                continue;
            }

            AddNewFile(activeNode, _input[index]);
            index++;
        }
        
        BuildFileSystem(activeNode, index);
    }

    private static void AddNewDirectory(Directory activeNode, string s)
    {
        activeNode.Directories.Add(new Directory() { Name = s.Split(" ")[1], Parent = activeNode });
    }

    private static void AddNewFile(Directory activeNode, string s)
    {
        var newFile = new File()
        {
            Name = s.Split(" ")[1], 
            Size = int.Parse(s.Split(" ")[0]), 
            Parent = activeNode
        };
        
        activeNode.Files.Add(newFile);
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