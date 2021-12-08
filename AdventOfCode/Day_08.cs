using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day08: BaseDay
    {
        private readonly string _input;

        public Day08()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input
                .Replace("\r", "")
                .Split("\n")
                .Select(c
                    => c.Split(" | ")
                        .Last().Split(" ")
                        .Select(f => new[] { 2, 3, 4, 7 }.Contains(f.Length) ? 1 : 0)
                        .Sum()
                )
                .Sum()
                .ToString());

        public override ValueTask<string> Solve_2() =>
            new(_input
                .Replace("\r", "")
                .Split("\n")
                .Select(c
                    => c.Split(" | ")[0].Trim()
                        .Split(" ")
                        .Pipe(source =>
                            c.Split(" | ")[1].Trim()
                                .Split(" ").Select(f
                                    => f.Pipe(y
                                        => y.Select(x
                                            => source.SelectMany(t => t).Count(v => v == x)).Sum())
                                )
                                .Select(t => t == 42 ? 0 : t == 17 ? 1 : t == 34 ? 2 : t == 39 ? 3 : t == 30 ? 4 :
                                    t == 37 ? 5 : t == 41 ? 6 : t == 25 ? 7 : t == 49 ? 8 : 9 ))
                ).Select(c => c.Aggregate(0, (n, i) => n * 10 + i))
                .Sum().ToString());
    }
}