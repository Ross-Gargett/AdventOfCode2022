namespace AdventOfCode2022.Models;

public class ForestVisibilityHelper
{
    private int[,] _trees;

    public ForestVisibilityHelper(int[,] trees)
    {
        _trees = trees;
    }
    
    public int CountVisibleTrees()
    {
        var visibleTrees = (_trees.GetLength(0) * 2) 
                           + (_trees.GetLength(1) * 2) 
                           - 4;
        
        for (var row = 1; row < _trees.GetLength(0) - 1; row++)
        {
            for (var col = 1; col < _trees.GetLength(1) - 1; col++)
            {
                var height = _trees[row, col];

                if (VisibleInRow(height, row, col) || VisibleInColumn(height, row, col))
                {
                    visibleTrees++;
                }
            } 
        }

        return visibleTrees;
    }
    
    private bool VisibleInRow(int height, int row, int col)
    {
        return VisibleFromLeft(height, row, col) || VisibleFromRight(height, row, col);
    }

    private bool VisibleFromLeft(int height, int row, int col)
    {
        for (var i = col - 1; i >= 0; i--)
        {
            if (_trees[row, i] >= height)
                return false;
        }

        return true;
    }

    private bool VisibleFromRight(int height, int row, int col)
    {
        for (var i = col + 1; i < _trees.GetLength(1); i++)
        {
            if (_trees[row, i] >= height)
                return false;
        }

        return true;
    }

    private bool VisibleInColumn(int height, int row, int col)
    {
        return VisibleFromAbove(height, row, col) || VisibleFromBelow(height, row, col);
    }

    private bool VisibleFromAbove(int height, int row, int col)
    {
        for (var i = row - 1; i >= 0; i--)
        {
            if (_trees[i, col] >= height)
                return false;
        }

        return true;
    }

    private bool VisibleFromBelow(int height, int row, int col)
    {
        for (var i = row + 1; i < _trees.GetLength(0); i++)
        {
            if (_trees[i, col] >= height)
                return false;
        }

        return true;
    }
}