using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public sealed class Day02 : BaseDay
    {
        private readonly string _input;
        
        public Day02()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Split('\n')
                .Select(c => (c.Split(" ")[0][0], int.Parse(c.Split(" ")[1])))
                .Aggregate(new[] { 0, 0 }, (position, move) =>
                        move.Item1 == 'f' ? new[] { position[0] + move.Item2, position[1] } :
                        move.Item1 == 'd' ? new[] { position[0], position[1] + move.Item2 } :
                        move.Item1 == 'u' ? new[] { position[0], position[1] - move.Item2 } :
                        throw new ArgumentOutOfRangeException(),
                    f => f[0] * f[1])
                .ToString());

        public override ValueTask<string> Solve_2()=>
            new(_input.Split('\n')
                .Select(c => (c.Split(" ")[0][0], int.Parse(c.Split(" ")[1])))
                .Aggregate(new[] { 0, 0, 0 }, (position, move) =>
                        move.Item1 == 'f' ? new[] { position[0] + move.Item2, position[1] + move.Item2 * position[2], position[2] } :
                        move.Item1 == 'd' ? new[] { position[0], position[1], position[2] + move.Item2 } :
                        move.Item1 == 'u' ? new[] { position[0], position[1], position[2] - move.Item2 } :
                        throw new ArgumentOutOfRangeException(),
                    f => f[0] * f[1])
                .ToString());
    }
}