
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;
using simd_experiment;

var config = ManualConfig.Create(DefaultConfig.Instance)
    .AddExporter(CsvExporter.Default)
    .AddDiagnoser(MemoryDiagnoser.Default)
    .AddDiagnoser(ThreadingDiagnoser.Default);

var summary = BenchmarkRunner.Run<VectorSumBenchmark>(config);