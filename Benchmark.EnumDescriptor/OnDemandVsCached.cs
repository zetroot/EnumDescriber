using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using EnumDesriptor;

namespace Benchmark.EnumDescriptor
{
    public class OnDemandVsCached
    {
        private StubEnum[]? data;

        [Params(100, 10_000)]
        public int N;

        private string OnDemandImpl(StubEnum value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field is null) return value.ToString();

            var attr = field.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }

        [GlobalSetup]
        public void Setup()
        {
            var rng = new Random();
            data = new StubEnum[N];
            for (int i = 0; i < N; ++i)
                data[i] = (StubEnum)rng.Next(0, 21);
        }

        [Benchmark]
        public List<string> OnDemand()
        {
            var result = new List<string>(N);
            if (data is null) throw new Exception();
            foreach (var value in data)
            {
                result.Add(OnDemandImpl(value));
            }
            return result;
        }

        [Benchmark]
        public List<string> Cached()
        {
            var result = new List<string>(N);
            if (data is null) throw new Exception();
            foreach (var value in data)
            {
                result.Add(value.GetDescription());
            }
            return result;
        }
    }
}
