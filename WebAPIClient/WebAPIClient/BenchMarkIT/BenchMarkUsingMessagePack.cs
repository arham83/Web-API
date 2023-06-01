using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using BenchmarkDotNet.Attributes;
using WebAPIClient.Message;
using WebAPIClient.SerializerDeserializer;
using System.IO;
using WebAPIClient.Miscellaneous;

namespace WebAPIClient.BenchMarkIT
{
    public class BenchMarkMessagePack
    {
        private readonly FullMessage SFM;
        public Byte[] mpBytes1;
        private readonly OptimizedMessage SOM;
        public Byte[] mpBytes2;
        private readonly FullMessage BFM;
        public Byte[] mpBytes3;
        private readonly OptimizedMessage BOM;
        public Byte[] mpBytes4;
        private readonly APICalls _req;

        public BenchMarkMessagePack()
        {
            SFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\smallFull.json"));
            BFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\bigFull.json"));
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\smallOptimized.json"));
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\bigOptimized.json"));
            _req = new  APICalls("http://localhost:32872/values");
        }

        [Benchmark]
        public async Task Evaluate_UsingWebAPI_SFM()
        {
            mpBytes1 = MessagePackSerializer.Serialize(SFM);
            await _req.Post(mpBytes1, "/FM");
        }
        
        [Benchmark]
        public async Task Evaluate_UsingWebAPI_SOM()
        {
            mpBytes2 = MessagePackSerializer.Serialize(SOM);
            await _req.Post(mpBytes2, "/OM");
        }

        // Big Full Sized Message 

        [Benchmark]
        public async Task Evaluate_UsingWebAPI_BFM()
        {
            mpBytes3 = MessagePackSerializer.Serialize(BFM);
            await _req.Post(mpBytes3, "/FM");
        }

        // Big Optimized Message 

        [Benchmark]
        public async Task Evaluate_UsingWebAPI_BOM()
        {
            mpBytes4 = MessagePackSerializer.Serialize(BOM);
            await _req.Post(mpBytes4, "/OM");
        }

    }
}