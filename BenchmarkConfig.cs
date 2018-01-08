using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;

namespace ImmutableDictionaryBenchmark
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(
                new Job("CollectionBenchmarkJob", RunMode.Dry, EnvMode.RyuJitX64)
                {
                    Env = { Runtime = Runtime.Core },
                    Run = {
                        LaunchCount = 1,
                        WarmupCount = 0,
                        TargetCount = 5
                         },
                });
        }
    }
}