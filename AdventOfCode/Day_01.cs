using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public sealed class Day01 : BaseDay
    {
        private readonly string _input;

        public Day01()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1() =>
            new(_input.Split('\n')
                .Select(int.Parse)
                .Windowed(2)
                .Count(c => c[0] < c[1])
                .ToString());


        public override ValueTask<string> Solve_2() => 
            new(_input.Split('\n')
                .Select(int.Parse)
                .Windowed(3)
                .Select(c=> c.Sum())
                .Windowed(2)
                .Count(c => c[0] < c[1])
                .ToString());
    }
}


