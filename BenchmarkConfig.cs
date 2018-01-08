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

            // The same, using the .With() factory methods:
            // Add(
            //     Job.Dry
            //     .With(Platform.X64)
            //     .With(Jit.RyuJit)
            //     .With(Runtime.Core)
            //     .WithLaunchCount(5)
            //     .WithIterationTime(TimeInterval.Millisecond * 200)
            //     .WithId("CollectionBenchmarkJob")); // IMPORTANT: Id assignment should be the last call in the chain or the id will be lost.
        }
    }
}