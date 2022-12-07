// See https://aka.ms/new-console-template for more information

using System.Text;
using AdventOfCode2022.Models;

namespace AdventOfCode2022.Solvers.DaySolvers;

internal class ProblemSolverDay5Part1 : IProblemSolver
{
    private Stack<char>[] _stacks;
    private readonly List<List<int>> _instructions = new();

    public ProblemSolverDay5Part1(IEnumerable<string> input)
    {
        InitializeStacks();
        ParseInstructions(input);
    }

    private void InitializeStacks()
    {
        _stacks = new Stack<char>[10];
        _stacks[1] = new Stack<char>(new[] { 'W', 'R', 'F' });
        _stacks[2] = new Stack<char>(new[] { 'T', 'H', 'M', 'C', 'D', 'V', 'W', 'P' });
        _stacks[3] = new Stack<char>(new[] { 'P', 'M', 'Z', 'N', 'L' });
        _stacks[4] = new Stack<char>(new[] { 'J', 'C', 'H', 'R' });
        _stacks[5] = new Stack<char>(new[] { 'C', 'P', 'G', 'H', 'Q', 'T', 'B' });
        _stacks[6] = new Stack<char>(new[] { 'G', 'C', 'W', 'L', 'F', 'Z' });
        _stacks[7] = new Stack<char>(new[] { 'W', 'V', 'L', 'Q', 'Z', 'J', 'G', 'C' });
        _stacks[8] = new Stack<char>(new[] { 'P', 'N', 'R', 'F', 'W', 'T', 'V', 'C' });
        _stacks[9] = new Stack<char>(new[] { 'J', 'W', 'H', 'G', 'R', 'S', 'V' });
    }
    
    private void ParseInstructions(IEnumerable<string> input)
    {
        input = input.Select(x =>
            x.Replace("move ", "")
                .Replace("from ", "")
                .Replace("to ", "")).ToList();

        foreach (var line in input)
        {
            _instructions.Add(
                line.Split(' ')
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse)
                    .ToList());
        }
    }

    public string Solve()
    {
        PerformInstructions();
        
        var messageBuilder = new StringBuilder();

        foreach (var stack in _stacks.Skip(1))
        {
            messageBuilder.Append(stack.Peek());
        }
        
        return messageBuilder.ToString();
    }

    private void PerformInstructions()
    {
        foreach (var instruction in _instructions)
        {
            var totalToMove = instruction.ElementAt(0);
            var startStack = instruction.ElementAt(1);
            var targetStack = instruction.ElementAt(2);

            for (var i = 0; i < totalToMove; i++)
            {
                _stacks[targetStack].Push(_stacks[startStack].Pop());
            }
        }
    }
}