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

        public static TResult PipeWithFirst<T, TResult>(this IEnumerable<T> source, Func<IEnumerable<T>, T, TResult> func)
        {
            return func(source, source.First());
        }
        
        public static TResult Pipe<T, TResult>(this IEnumerable<T> source, Func<IEnumerable<T>, TResult> func)
        {
            return func(source);
        }
        
        public static TResult Pipe<T, R, TResult>(this ValueTuple<IEnumerable<T>, IEnumerable<R>> source, Func<IEnumerable<T>, IEnumerable<R>, TResult> func)
        {
            return func(source.Item1, source.Item2);
        }

        public static IEnumerable<int> AsRange(this int count)
        {
            return Enumerable.Range(0, count);
        }

        public static T[] Apply<T>(this T[] arr, Action<T[]> action)
        {
            action.Invoke(arr);
            return arr;
        }

        public static IEnumerable<T> Apply<T>(this IEnumerable<T> arr, Action<IEnumerable<T>> action)
        {
            action.Invoke(arr);
            return arr;
        }
    }
}