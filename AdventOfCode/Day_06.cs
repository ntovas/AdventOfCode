﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day06 : BaseDay
    {
        private readonly string _input;

        public Day06()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input
                .Replace("\r", "")
                .Split(',')
                .Select(int.Parse)
                .Transform(list =>
                    list.Aggregate(new long[9], (longs, i) =>
                        longs.RunAndReturn(arr => arr[i]++)
                    )
                ).Transform(arr =>
                    80.AsRange()
                        .Aggregate(arr.ToArray(), (longs, i) =>
                            longs.RunAndReturn(longs1 => longs1[(i + 7) % 9] += longs1[i % 9])
                        )
                ).Sum().ToString());

        public override ValueTask<string> Solve_2()=>
            new(_input
                .Replace("\r", "")
                .Split(',')
                .Select(int.Parse)
                .Transform(list =>
                    list.Aggregate(new long[9], (longs, i) =>
                        longs.RunAndReturn(arr => arr[i]++)
                    )
                ).Transform(arr =>
                    256.AsRange()
                        .Aggregate(arr.ToArray(), (longs, i) =>
                            longs.RunAndReturn(longs1 => longs1[(i + 7) % 9] += longs1[i % 9])
                        )
                ).Sum().ToString());
    }
}