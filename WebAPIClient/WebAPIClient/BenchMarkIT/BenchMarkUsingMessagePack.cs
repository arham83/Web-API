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
        private readonly Byte[] mpBytes1;
        private readonly OptimizedMessage SOM;
        private readonly Byte[] mpBytes2;
        private readonly FullMessage BFM;
        private readonly Byte[] mpBytes3;
        private readonly OptimizedMessage BOM;
        private readonly Byte[] mpBytes4;
        private readonly APICalls _req;

        public BenchMarkMessagePack()
        {
            SFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\smallFull.json"));
            BFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\bigFull.json"));
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\smallOptimized.json"));
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\bigOptimized.json"));
            mpBytes1 = MessagePackSerializer.Serialize(SFM);
            mpBytes2 = MessagePackSerializer.Serialize(SOM);
            mpBytes3 = MessagePackSerializer.Serialize(BFM);
            mpBytes4 = MessagePackSerializer.Serialize(BOM);
            _req = new  APICalls("http://localhost:32872/values");

        }


        // Small Full Sized Message 
        [Benchmark]
        public void MessagePackSerialization_SFM()
        {
            MessagePackSerializer.Serialize(SFM);
        }
        [Benchmark]
        public async Task TransmissionTime_UsingWebAPI_SFM()
        {
            await _req.Post(mpBytes1, "/FM");
        }
        [Benchmark]
        public void MessagePackDeserialization_SFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes1);
        }

        // Small Optimized Message 

        [Benchmark]
        public void MessagePackSerialization_SOM()
        {
            MessagePackSerializer.Serialize(SOM);
        }
        [Benchmark]
        public async Task TransmissionTime_UsingWebAPI_SOM()
        {
            await _req.Post(mpBytes2, "/OM");
        }
        [Benchmark]
        public void MessagePackDeserialization_SOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes2);
        }

        // Big Full Sized Message 

        [Benchmark]
        public void MessagePackSerialization_BFM()
        {
            MessagePackSerializer.Serialize(BFM);
        }
        [Benchmark]
        public async Task TransmissionTime_UsingWebAPI_BFM()
        {
            await _req.Post(mpBytes3, "/FM");
        }
        [Benchmark]
        public void MessagePackDeserialization_BFM()
        {
            MessagePackSerializer.Deserialize<FullMessage>(mpBytes3);
        }

        // Big Optimized Message 

        [Benchmark]
        public void MessagePackSerialization_BOM()
        {
            MessagePackSerializer.Serialize(BOM);
        }
        [Benchmark]
        public async Task TransmissionTime_UsingWebAPI_BOM()
        {
            await _req.Post(mpBytes4, "/OM");
        }
        [Benchmark]
        public void MessagePackDeserialization_BOM()
        {
            MessagePackSerializer.Deserialize<OptimizedMessage>(mpBytes4);
        }
    }
}