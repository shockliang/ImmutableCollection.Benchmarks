using System.Collections.Generic;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace ImmutableDictionaryBenchmark
{
    [Config(typeof(BenchmarkConfig))]
    [KeepBenchmarkFiles]
    public class DictionaryReadBenchmark
    {
        ImmutableDictionary<object, object> immutableDicForRead;
        Dictionary<object, object> dictionaryForRead;

        [GlobalSetup]
        public void InitializeData()
        {
            immutableDicForRead = ImmutableDictionary<object, object>.Empty;
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                immutableDicForRead = immutableDicForRead.SetItem(obj, obj);
            }

            dictionaryForRead = new Dictionary<object, object>();
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                dictionaryForRead[obj] = obj;
            }
        }

        [Benchmark]
        public void UisngDictionaryGetValue()
        {
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                object value;
                dictionaryForRead.TryGetValue(i, out value);
            }
        }

        [Benchmark]
        public void UsingImmutableDictionaryGetValue()
        {
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                object value;
                immutableDicForRead.TryGetValue(i, out value);
            }
        }
    }
}