using System.Collections.Generic;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace ImmutableDictionaryBenchmark
{
    [Config(typeof(BenchmarkConfig))]
    [KeepBenchmarkFiles]
    public class ListBenchmark
    {
        [Benchmark]
        public void UsingList()
        {
            var list = new List<object>();
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                list.Add(obj);
            }
        }

        [Benchmark]
        public void ImmutableList()
        {
            var list = ImmutableList<object>.Empty;
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                list.Add(obj);
            }
        }

        [Benchmark]
        public void ToImmutableList()
        {
            var list = new List<object>();

            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                list.Add(obj);
            }

            var iList = list.ToImmutableList<object>();
        }
    }
}