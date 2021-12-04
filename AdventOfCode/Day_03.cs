using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day03: BaseDay
    {
        private readonly string _input;
        
        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Split('\n')
                .TransformWithFirst(
                    (source, first) =>  Convert.ToInt32(string.Join("", (first.Length -1)
                                            .AsRange()
                                            .Select(c => source.Select(i => i[c]))
                                            .Select(c => c.GroupBy(ch => ch)
                                                .OrderByDescending(ch => ch.Count())
                                                .Select(ch => ch.Key)
                                                .FirstOrDefault())),2) 
                                        *
                                        Convert.ToInt32(string.Join("", (first.Length -1)
                                            .AsRange()
                                            .Select(c => source.Select(i => i[c]))
                                            .Select(c => c.GroupBy(ch => ch)
                                                .OrderBy(ch => ch.Count())
                                                .Select(ch => ch.Key)
                                                .FirstOrDefault())),2) 

                ).ToString());

        public override ValueTask<string> Solve_2()
        {
            throw new System.NotImplementedException();
        }
    }
}