using System;
using BenchmarkDotNet.Running;

namespace Benchmark.EnumDescriber
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<OnDemandVsCached>();
        }
    }

}
