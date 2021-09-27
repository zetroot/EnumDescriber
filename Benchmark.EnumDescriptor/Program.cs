using System;
using BenchmarkDotNet.Running;

namespace Benchmark.EnumDescriptor
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<OnDemandVsCached>();
        }
    }

}
