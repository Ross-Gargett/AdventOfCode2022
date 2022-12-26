namespace AdventOfCode2022.Models;

public static class MonkeyParser
{
    public static Monkey ParseMonkey(string[] chunk)
    {
        var itemString = chunk[1].Split(": ")[1];
        var items = itemString
            .Split(", ")
            .Select(long.Parse)
            .ToList();

        return new Monkey(items, 
                chunk[2].Split(": new = ")[1],
                int.Parse(chunk[3].Split(": divisible by ")[1]), 
                int.Parse(chunk[4].Split("monkey ")[1]),
                int.Parse(chunk[5].Split("monkey ")[1]));
    }
}