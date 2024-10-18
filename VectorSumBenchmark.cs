using BenchmarkDotNet.Attributes;

namespace simd_experiment;

[IterationCount(20)]
public class VectorSumBenchmark
{
    private double[] longNumbersArray1;
    private double[] longNumbersArray2;
    private double[] shortNumbersArray1;
    private double[] shortNumbersArray2;

    [GlobalSetup]
    public void Setup()
    {
        var rand = new Random();
        longNumbersArray1 = new double[10_000_000];
        longNumbersArray2 = new double[10_000_000];
        shortNumbersArray1 = new double[1000];
        shortNumbersArray2 = new double[1000];

        for (int i = 0; i < longNumbersArray1.Length; i++)
        {
            longNumbersArray1[i] = rand.Next(10_000_000, 1_000_000_000);
            longNumbersArray2[i] = rand.Next(10_000_000, 1_000_000_000);
        }

        for (int i = 0; i < shortNumbersArray1.Length; i++)
        {
            shortNumbersArray1[i] = rand.NextDouble() / 1_000_000;
            shortNumbersArray2[i] = rand.NextDouble() / 1_000_000;
        }
    }
    [Benchmark]
    public void VectorSumSimdLongArraysLongNumbers() => SimdVectorSum.Sum(longNumbersArray1, longNumbersArray2);
    
    [Benchmark]
    public void NormalVectorSumLongArraysLongNumbers() => NormalVectorSum.Sum(longNumbersArray1, longNumbersArray2);
    
    [Benchmark]
    public void VectorSumSimdLongArraysSmallNumbers() => SimdVectorSum.Sum(shortNumbersArray1, shortNumbersArray2);
    
    [Benchmark]
    public void NormalVectorSumLongArraysSmallNumbers() => NormalVectorSum.Sum(shortNumbersArray1, shortNumbersArray2);
    
}