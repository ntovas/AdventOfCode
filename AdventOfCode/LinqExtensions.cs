using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;

namespace AdventOfCode
{
    public static class LinqExtensions
    {
        public static IEnumerable<T[]> Windowed<T>(this IEnumerable<T> source, int window)
        {
            return SeqModule.Windowed(window, source);
        }

        public static TResult TransformWithFirst<T, TResult>(this IEnumerable<T> source, Func<IEnumerable<T>, T, TResult> func)
        {
            return func(source, source.First());
        }

        public static IEnumerable<int> AsRange(this int count)
        {
            return Enumerable.Range(0, count);
        }
    }
}