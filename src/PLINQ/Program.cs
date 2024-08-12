using BenchmarkDotNet.Running;

namespace PLINQ;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<MonteCarlo>();
    }
}