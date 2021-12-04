using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day04 : BaseDay
    {
        private readonly string _input;

        public Day04()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Replace("\r", "").Split("\n\n")
                .TransformWithFirst((source, first) =>
                    (first.Split(",").Select(int.Parse),
                        source.Skip(1).Select(c
                            => c.Split('\n')
                                .Select(i
                                    => i.Trim().Split(' ')
                                        .Where(f => !string.IsNullOrWhiteSpace(f)).Select(int.Parse).ToArray())
                                .ToArray()).ToArray()
                    ))
                .Transform((numbers, boards)
                    => numbers.Aggregate((-1, boards), (tuple, i) =>
                        tuple.boards.Any(board
                            => board.Length.AsRange().Any(y => board[y].All(c => c == -1))
                               || board.Length.AsRange().Any(y => board.All(c => c[y] == -1)))
                            ? (tuple.Item1, tuple.boards)
                            : (tuple.Item1 = i, tuple.boards.Select(board => board.Length.AsRange()
                                .Select(y =>
                                    board.Length.AsRange()
                                        .Select(x => board[y][x] = board[y][x] == i ? -1 : board[y][x])
                                        .ToArray()).ToArray())
                            ), tuple => (tuple.boards.FirstOrDefault(board
                            => board.Length.AsRange().Any(y => board[y].All(c => c == -1))
                               || board.Length.AsRange().Any(y => board.All(c => c[y] == -1))) ?? Array.Empty<int[]>())
                        .SelectMany(c => c).Where(c => c != -1).Sum() * tuple.Item1)).ToString());

        public override ValueTask<string> Solve_2() =>
            new(_input.Replace("\r", "").Split("\n\n")
                .TransformWithFirst((source, first) =>
                    (first.Split(",").Select(int.Parse),
                        source.Skip(1).Select(c
                            => c.Split('\n')
                                .Select(i
                                    => i.Trim().Split(' ')
                                        .Where(f => !string.IsNullOrWhiteSpace(f)).Select(int.Parse).ToArray())
                                .ToArray()).ToArray()
                    ))
                .Transform((numbers, boards)
                    => numbers.Aggregate((-1, boards), (tuple, i) =>
                        tuple.boards.Any(board
                            => board.Length.AsRange().Any(y => board[y].All(c => c == -1))
                               || board.Length.AsRange().Any(y => board.All(c => c[y] == -1)))
                            ? (tuple.Item1, tuple.boards)
                            : (tuple.Item1 = i, tuple.boards.Select(board => board.Length.AsRange()
                                    .Select(y =>
                                        board.Length.AsRange()
                                            .Select(x => board[y][x] = board[y][x] == i ? -1 : board[y][x])
                                            .ToArray()).ToArray()).Transform(bs => bs.Count() <= 1
                                    ? bs
                                    : bs.Where(board =>
                                        !board.Length.AsRange().Any(y => board[y].All(c => c == -1))
                                        && !board.Length.AsRange().Any(y => board.All(c => c[y] == -1))
                                    ).ToArray())
                            ), tuple => (tuple.boards.FirstOrDefault(board
                            => board.Length.AsRange().Any(y => board[y].All(c => c == -1))
                               || board.Length.AsRange().Any(y => board.All(c => c[y] == -1))) ?? Array.Empty<int[]>())
                        .SelectMany(c => c).Where(c => c != -1).Sum() * tuple.Item1)).ToString());
    }
}