namespace AdventOfCode2022.Models;

public class FileSystem
{
    public FileSystem()
    {
        Root = new Directory()
        {
            Name = "/",
            Parent = null
        };
    }
    
    public Directory Root { get; set; }
}

public class Directory
{
    public string Name { get; set; }

    public Directory Parent { get; set; }
    
    public List<Directory> Directories { get; set; } = new();

    public List<File> Files { get; set; } = new();
}

public class File
{
    public Directory Parent { get; set; }
    
    public string Name { get; set; }

    public int Size { get; set; }
}