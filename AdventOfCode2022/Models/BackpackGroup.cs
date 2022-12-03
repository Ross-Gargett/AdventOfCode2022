namespace AdventOfCode2022.Models;

public class BackpackGroup
{
    public BackpackGroup(string[] group)
    { 
        Backpack1 = new Compartment(group[0]);
        Backpack2 = new Compartment(group[1]);
        Backpack3 = new Compartment(group[2]);
    }
    
    public Compartment Backpack1 { get; set; }
    public Compartment Backpack2 { get; set; }
    public Compartment Backpack3 { get; set; }

    public HashSet<char> GetDuplicates()
    {
        var commonKeys = new HashSet<char>(Backpack1.ContentsSummary.Keys);
        commonKeys.IntersectWith(Backpack2.ContentsSummary.Keys);
        commonKeys.IntersectWith(Backpack3.ContentsSummary.Keys);

        return commonKeys;
    }
}