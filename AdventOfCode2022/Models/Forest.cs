using AdventOfCode2022.Helpers;

namespace AdventOfCode2022.Models;

public class Forest
{
    private readonly ForestParser _parser;
    
    public Forest(List<string> input)
    {
        _parser = new ForestParser();
        _trees = _parser.ParseTrees(input);
    }

    private int[,] _trees;

    public int CountVisibleTrees()
    {
        var helper = new ForestVisibilityHelper(_trees);
        return helper.CountVisibleTrees();
    }

    public int GetHighestScenicScore()
    {
        var helper = new VisibilityScoreHelper(_trees);

        var scores = helper.GetVisibilityScores();

        return scores.Max();
    }
}