namespace AdventOfCode2022.Models;

public class CompartmentalizedBackpack
{
    public CompartmentalizedBackpack(string contents)
    {
        var firstHalfLength = contents.Length / 2;
        var secondHalfLength = contents.Length - firstHalfLength;

        Compartment1 = new Compartment(contents[..firstHalfLength]);
        Compartment2 = new Compartment(contents.Substring(firstHalfLength, secondHalfLength));
    }
    
    public Compartment Compartment1 { get; set; }
    public Compartment Compartment2 { get; set; }

    public Dictionary<char, int> GetDuplicates()
    {
        var commonKeys = new HashSet<char>(Compartment1.ContentsSummary.Keys);
        commonKeys.IntersectWith(Compartment2.ContentsSummary.Keys);

        return commonKeys
            .ToDictionary(key => key, key => Compartment1.ContentsSummary[key] + Compartment2.ContentsSummary[key]);
    }
}

public class Compartment
{
    public Compartment(string contents)
    {
        foreach (var letter in contents.ToCharArray())
        {
            if (ContentsSummary.ContainsKey(letter))
            {
                ContentsSummary[letter]++;
                continue;
            }

            ContentsSummary[letter] = 1;
        }
    }

    public Dictionary<char, int> ContentsSummary { get; set; } = new();
}