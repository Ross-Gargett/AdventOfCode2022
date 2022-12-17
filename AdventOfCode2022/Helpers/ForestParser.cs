namespace AdventOfCode2022.Helpers;

public class ForestParser
{
    public int[,] ParseTrees(List<string> input)
    {
        var trees = new int[input.Count, input[0].Length];

        for (var row = 0; row < input.Count; row++)
        {
            var splitRow = input.ElementAt(row).ToCharArray();

            for (var col = 0; col < splitRow.Length; col++)
            {
                trees[row, col] = int.Parse($"{splitRow[col]}");
            }
        }
        
        return trees;
    }
}