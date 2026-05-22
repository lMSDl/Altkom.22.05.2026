using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VSDiagnostics;

[CPUUsageDiagnoser]
public class ProcessDataBenchmark
{
    private List<int> _data = null!;
    [GlobalSetup]
    public void Setup()
    {
        var rand = new Random(42);
        _data = Enumerable.Range(0, 1_000_000).Select(_ => rand.Next(1, 1000)).ToList();
    }

    [Benchmark(Baseline = true)]
    public int ProcessData_Original()
    {
        var query = _data.Where(x => x % 2 == 0 && x > 500);
        var count = query.Count();
        var max = query.Max();
        var sum = query.Sum();
        return count + max + sum;
    }

    [Benchmark]
    public int ProcessData_ToArray()
    {
        var query = _data.Where(x => x % 2 == 0 && x > 500).ToArray();
        var count = query.Count();
        var max = query.Max();
        var sum = query.Sum();
        return count + max + sum;
    }

    [Benchmark]
    public int ProcessData_SinglePass()
    {
        int count = 0, max = int.MinValue, sum = 0;
        foreach (var x in _data)
        {
            if (x % 2 == 0 && x > 500)
            {
                count++;
                sum += x;
                if (x > max) max = x;
            }
        }
        return count + max + sum;
    }
}