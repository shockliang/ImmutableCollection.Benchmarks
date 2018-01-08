using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ImmutableDictionaryBenchmark
{
    [Config(typeof(BenchmarkConfig))]
    [KeepBenchmarkFiles]
    public class DictionaryWriteBenchmark
    {
        [Benchmark]
        public void UsingDictionary()
        {
            var dic = new Dictionary<object, object>();
            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                dic[obj] = obj;
            }
        }



        [Benchmark]
        public void UsingImmutableDictionary()
        {
            var dic = ImmutableDictionary<object, object>.Empty;

            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                dic = dic.SetItem(obj, obj);
            }
        }

        [Benchmark]
        public void UsingImmutableDictionaryJustNumber()
        {
            var dic = ImmutableDictionary<object, object>.Empty;

            dic = dic.SetItems(Enumerable.Range(0, 10 * 1000 * 1000).Select(i =>
            {
                var obj = new object();
                return new KeyValuePair<object, object>(obj, obj);
            }));
        }

        [Benchmark]
        public void ImmutableDictionaryBuilder()
        {
            var builder = ImmutableDictionary.CreateBuilder<object, object>();

            for (int i = 0; i < 10 * 1000 * 1000; i++)
            {
                var obj = new object();
                builder.Add(obj, obj);
            }
        }
    }

}