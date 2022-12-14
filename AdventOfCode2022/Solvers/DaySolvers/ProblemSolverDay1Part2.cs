// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay1Part2 : IProblemSolver
{
    private readonly List<int> _input = new();

    public ProblemSolverDay1Part2(IEnumerable<string> input)
    {
        var calSum = 0;
        
        foreach (var line in input)
        {
            if (line.Equals(string.Empty))
            {
                _input.Add(calSum);
                calSum = 0;
                continue;
            }
            
            calSum += int.Parse(line);
        }
        
        _input.Add(calSum);
        
        _input.Sort();
    }

    public string Solve()
    {
        return $"{_input.TakeLast(3).Sum()}";
    }
}