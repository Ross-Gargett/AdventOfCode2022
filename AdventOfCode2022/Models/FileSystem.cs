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

    public long TotalSize { get; set; }

    public List<long> GetDirectoriesSizes()
    {
        var sizes = new Dictionary<int, long>();

        RecurseDirectories(Root, sizes);

        TotalSize = sizes[Root.GetHashCode()];
        
        return sizes.Select(s => s.Value).ToList();
    }

    private long RecurseDirectories(Directory dir, Dictionary<int, long> sizes)
    {
        if (!dir.Directories.Any() == null || sizes.ContainsKey(dir.GetHashCode()))
            return 0;
        
        var size = dir.Files.Sum(f => (long)f.Size) 
                    + dir.Directories.Sum(x => RecurseDirectories(x, sizes));
        
        sizes[dir.GetHashCode()] = size;

        return size;
    }
}

public class Directory
{
    public string Name { get; set; }

    public Directory Parent { get; set; }
    
    public List<Directory> Directories { get; set; } = new();

    public List<File> Files { get; set; } = new();

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + Directories.GetHashCode();
            hash = hash * 23 + Files.GetHashCode();
            return hash;
        }
    }
}

public class File
{
    public Directory Parent { get; set; }
    
    public string Name { get; set; }

    public int Size { get; set; }
}