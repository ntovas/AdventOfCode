using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day05 : BaseDay
    {
        private readonly string _input;

        public Day05()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Replace("\r", "").Split("\n")
                .Select(l => string.Join("", l.Select(c => char.IsDigit(c) ? c : ',')))
                .Select(m => m.Split(",").Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(int.Parse).ToArray())
                .Where(c => c[0] == c[2] || c[1] == c[3])
                .Select(c =>
                    Enumerable.Range(0, Math.Max(Math.Abs(c[0] - c[2]), Math.Abs(c[1] - c[3])) + 1)
                        .Select(f =>
                        (
                            c[0] > c[2] ? c[0] - f : c[0] < c[2] ? c[0] + f : c[0],
                            c[1] > c[3] ? c[1] - f : c[1] < c[3] ? c[1] + f : c[1]
                        ))
                )
                .SelectMany(c => c)
                .GroupBy(c => c)
                .Count(c => c.Count() > 1)
                .ToString());

        public override ValueTask<string> Solve_2() =>
            new(_input.Replace("\r", "").Split("\n")
                .Select(l => string.Join("", l.Select(c => char.IsDigit(c) ? c : ',')))
                .Select(m => m.Split(",").Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(int.Parse).ToArray())
                .Select(c =>
                    Enumerable.Range(0, Math.Max(Math.Abs(c[0] - c[2]), Math.Abs(c[1] - c[3])) + 1)
                        .Select(f =>
                        (
                            c[0] > c[2] ? c[0] - f : c[0] < c[2] ? c[0] + f : c[0],
                            c[1] > c[3] ? c[1] - f : c[1] < c[3] ? c[1] + f : c[1]
                        ))
                )
                .SelectMany(c => c)
                .GroupBy(c => c)
                .Count(c => c.Count() > 1)
                .ToString());
    }
}