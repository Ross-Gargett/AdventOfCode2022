namespace AdventOfCode2022.Models;

public class VisibilityScoreHelper
{
    private int[,] _trees;

    public VisibilityScoreHelper(int[,] trees)
    {
        _trees = trees;
    }


    public List<int> GetVisibilityScores()
    {
        var scores = new List<int>();

        for (var row = 1; row < _trees.GetLength(0) - 1; row++)
        {
            for (var col = 1; col < _trees.GetLength(1) - 1; col++)
            {
                var height = _trees[row, col];

                scores.Add(CalculateVisibilityScore(height, row, col));
            } 
        }
        
        return scores;
    }

    private int CalculateVisibilityScore(int height, int row, int col)
    {
        var leftView = GetLeftView(height, row, col);
        var rightView = GetRightView(height, row, col);
        var upView = GetUpView(height, row, col);
        var downView = GetDownView(height, row, col);

        return leftView * rightView * upView * downView;
    }

    private int GetLeftView(int height, int row, int col)
    {
        var view = 0;
        
        for (var i = col - 1; i >= 0; i--)
        {
            view++;
            
            if (_trees[row, i] >= height)
                break;
        }

        return Math.Max(view, 1);
    }

    private int GetRightView(int height, int row, int col)
    {
        var view = 0;
        
        for (var i = col + 1; i < _trees.GetLength(1); i++)
        {
            view++;
            
            if (_trees[row, i] >= height)
                break;
        }

        return Math.Max(view, 1);
    }

    private int GetUpView(int height, int row, int col)
    {
        var view = 0;
        
        for (var i = row - 1; i >= 0; i--)
        {
            view++;
            
            if (_trees[i, col] >= height)
                break;
        }

        return Math.Max(view, 1);
    }

    private int GetDownView(int height, int row, int col)
    {
        var view = 0;
        
        for (var i = row + 1; i < _trees.GetLength(0); i++)
        {
            view++;
            
            if (_trees[i, col] >= height)
                break;
        }

        return Math.Max(view, 1);
    }
}