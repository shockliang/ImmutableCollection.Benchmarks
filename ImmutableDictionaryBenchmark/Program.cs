using System;
using BenchmarkDotNet.Running;

namespace ImmutableDictionaryBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DictionaryWriteBenchmark>();
            var summary2 = BenchmarkRunner.Run<ListBenchmark>();
            var summary3 = BenchmarkRunner.Run<DictionaryReadBenchmark>();

            // var switcher = new BenchmarkSwitcher(new[] {
            //                     typeof(DictionaryReadBenchmark),
            //                     typeof(DictionaryWriteBenchmark),
            //                     typeof(ListBenchmark)
            //                 });
            // switcher.Run(args);
        }
    }
}
