``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2846/21H2/November2021Update)
Intel Xeon CPU E5-1620 0 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 5.0.14 (5.0.1422.5710), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 5.0.14 (5.0.1422.5710), X64 RyuJIT AVX


```
|                           Method |         Mean |        Error |        StdDev |
|--------------------------------- |-------------:|-------------:|--------------:|
|     MessagePackSerialization_SFM |   1,949.6 μs |     32.91 μs |      56.76 μs |
| TransmissionTime_UsingWebAPI_SFM |   8,116.9 μs |    187.80 μs |     529.68 μs |
|   MessagePackDeserialization_SFM |   3,484.8 μs |     58.87 μs |      52.19 μs |
|     MessagePackSerialization_SOM |     605.2 μs |     12.09 μs |      23.59 μs |
| TransmissionTime_UsingWebAPI_SOM |   5,400.2 μs |    108.24 μs |     312.31 μs |
|   MessagePackDeserialization_SOM |     549.0 μs |     11.63 μs |      34.29 μs |
|     MessagePackSerialization_BFM | 154,036.3 μs |  1,659.02 μs |   1,385.36 μs |
| TransmissionTime_UsingWebAPI_BFM | 571,389.8 μs | 37,839.88 μs | 109,780.36 μs |
|   MessagePackDeserialization_BFM | 403,254.3 μs |  7,630.18 μs |   7,493.86 μs |
|     MessagePackSerialization_BOM |  33,422.9 μs |    655.21 μs |   1,518.55 μs |
| TransmissionTime_UsingWebAPI_BOM | 229,836.0 μs |  4,474.29 μs |  11,942.80 μs |
|   MessagePackDeserialization_BOM |  28,962.5 μs |    574.69 μs |   1,249.32 μs |
