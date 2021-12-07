using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day07: BaseDay
    {
        private readonly string _input;

        public Day07()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
           return new ValueTask<string>(_input
               .Replace("\r", "")
               .Split(',')
               .Select(int.Parse)
               .Transform(source =>
                   source.Max().AsRange()
                       .Select(c => source.Sum(f => Math.Abs(f - c)))
                       .Min()
               ).ToString());
        }

        public override ValueTask<string> Solve_2()
        {
            return new ValueTask<string>(_input
                .Replace("\r", "")
                .Split(',')
                .Select(int.Parse)
                .Transform(source =>
                    source.Max().AsRange()
                        .Select(c => 
                            source.Select(f => Math.Abs(f - c))
                                .Sum(x => x * (x + 1) / 2))
                        .Min()
                ).ToString());
        }
    }
}