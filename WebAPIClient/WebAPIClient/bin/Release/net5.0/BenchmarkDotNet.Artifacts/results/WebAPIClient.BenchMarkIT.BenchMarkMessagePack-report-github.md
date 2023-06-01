``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2965/21H2/November2021Update)
Intel Xeon CPU E5-1620 0 3.60GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.203
  [Host]     : .NET 5.0.14 (5.0.1422.5710), X64 RyuJIT AVX [AttachedDebugger]
  DefaultJob : .NET 5.0.14 (5.0.1422.5710), X64 RyuJIT AVX


```
|                   Method |       Mean |      Error |     StdDev |
|------------------------- |-----------:|-----------:|-----------:|
| Evaluate_UsingWebAPI_SFM |  10.895 ms |  0.2967 ms |  0.8465 ms |
| Evaluate_UsingWebAPI_SOM |   7.229 ms |  0.1877 ms |  0.5475 ms |
| Evaluate_UsingWebAPI_BFM | 801.538 ms | 23.0946 ms | 67.0018 ms |
| Evaluate_UsingWebAPI_BOM | 277.721 ms |  9.3091 ms | 27.0074 ms |
