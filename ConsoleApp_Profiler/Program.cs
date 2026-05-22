using System.Diagnostics;


    var data = GenerateData(1_000_000);

    var stopwatch = Stopwatch.StartNew();

    var result = ProcessData(data);

    stopwatch.Stop();
    Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($"Result: {result}");


static List<int> GenerateData(int size)
{
    var rand = new Random();
    return Enumerable.Range(0, size)
        .Select(_ => rand.Next(1, 1000))
        .ToList();
}

static int ProcessData(List<int> data)
{
    int count = 0, max = int.MinValue, sum = 0;
    foreach (var x in data)
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