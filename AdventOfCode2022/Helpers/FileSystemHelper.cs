namespace AdventOfCode2022.Helpers;

public class FileSystemHelper
{
    private readonly List<string> _input;
    
    public FileSystemHelper(List<string> input)
    {
        _input = input;
    }
    
    public void BuildFileSystem(Models.Directory activeNode, int index)
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

    private void HandleChangeDirectory(Models.Directory activeNode, int index)
    {
        var directory = _input[index].Replace("$ cd ", string.Empty);

        if (directory == "..")
            BuildFileSystem(activeNode.Parent, index + 1);
        else
            BuildFileSystem(activeNode.Directories
                .First(d => d.Name.Equals(directory, StringComparison.OrdinalIgnoreCase)), index + 1);
    }

    private void HandleAddDirectoryContents(Models.Directory activeNode, ref int index)
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

    private static void AddNewDirectory(Models.Directory activeNode, string s)
    {
        activeNode.Directories.Add(new Models.Directory() { Name = s.Split(" ")[1], Parent = activeNode });
    }

    private static void AddNewFile(Models.Directory activeNode, string s)
    {
        var newFile = new Models.File()
        {
            Name = s.Split(" ")[1], 
            Size = int.Parse(s.Split(" ")[0]), 
            Parent = activeNode
        };
        
        activeNode.Files.Add(newFile);
    }
}