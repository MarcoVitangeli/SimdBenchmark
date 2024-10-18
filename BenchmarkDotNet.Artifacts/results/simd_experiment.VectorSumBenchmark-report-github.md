```

BenchmarkDotNet v0.14.0, Ubuntu 22.04.5 LTS (Jammy Jellyfish)
AMD Ryzen 7 5700G with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.201
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  Job-LTKGXP : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

IterationCount=20  

```
| Method                                | Mean          | Error       | StdDev      | Completed Work Items | Lock Contentions | Gen0     | Gen1     | Gen2     | Allocated   |
|-------------------------------------- |--------------:|------------:|------------:|---------------------:|-----------------:|---------:|---------:|---------:|------------:|
| VectorSumSimdLongArraysLongNumbers    | 18,198.004 μs | 411.6918 μs | 457.5944 μs |                    - |                - | 125.0000 | 125.0000 | 125.0000 | 78125.13 KB |
| NormalVectorSumLongArraysLongNumbers  | 18,111.165 μs |  27.3336 μs |  26.8452 μs |                    - |                - | 125.0000 | 125.0000 | 125.0000 | 78125.13 KB |
| VectorSumSimdLongArraysSmallNumbers   |      1.060 μs |   0.0079 μs |   0.0091 μs |                    - |                - |   0.0954 |        - |        - |     7.84 KB |
| NormalVectorSumLongArraysSmallNumbers |      1.359 μs |   0.1321 μs |   0.1521 μs |                    - |                - |   0.0954 |        - |        - |     7.84 KB |
