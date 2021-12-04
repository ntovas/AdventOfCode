using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day03 : BaseDay
    {
        private readonly string _input;

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Split('\n')
                .TransformWithFirst(
                    (source, first) => Convert.ToInt32(string.Join("", (first.Length - 1)
                                           .AsRange()
                                           .Select(c => source.Select(i => i[c]))
                                           .Select(c => c.GroupBy(ch => ch)
                                               .OrderByDescending(ch => ch.Count())
                                               .Select(ch => ch.Key)
                                               .FirstOrDefault())), 2)
                                       *
                                       Convert.ToInt32(string.Join("", (first.Length - 1)
                                           .AsRange()
                                           .Select(c => source.Select(i => i[c]))
                                           .Select(c => c.GroupBy(ch => ch)
                                               .OrderBy(ch => ch.Count())
                                               .Select(ch => ch.Key)
                                               .FirstOrDefault())), 2)
                ).ToString());

        public override ValueTask<string> Solve_2() =>
            new(_input.Replace("\r", "").Split('\n')
                .TransformWithFirst(
                    (source, first) => 
                                        Convert.ToInt32(string.Join("", (first.Length)
                                           .AsRange()
                                           .Aggregate(((char)0, source), (tuple, i) => tuple.source.Count() > 1
                                               ? (tuple.Item1 = tuple.source.Select(c => c[i])
                                                       .Transform(s =>
                                                           s.Count(ch => ch == '1') >= s.Count(ch => ch == '0')
                                                               ? '1'
                                                               : '0'),
                                                   tuple.source.Where(c => c[i] == tuple.Item1))
                                               : (tuple.Item1, tuple.source))
                                           .source), 2)
                                       *
                                        Convert.ToInt32(string.Join("", (first.Length)
                                            .AsRange()
                                            .Aggregate(((char)0, source), (tuple, i) => tuple.source.Count() > 1
                                                ? (tuple.Item1 = tuple.source.Select(c => c[i])
                                                        .Transform(s =>
                                                            s.Count(ch => ch == '1') >= s.Count(ch => ch == '0')
                                                                ? '0'
                                                                : '1'),
                                                    tuple.source.Where(c => c[i] == tuple.Item1))
                                                : (tuple.Item1, tuple.source))
                                            .source), 2)
                ).ToString());
    }
}