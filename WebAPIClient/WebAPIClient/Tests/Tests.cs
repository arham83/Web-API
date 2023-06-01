using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.Message;
using WebAPIClient.Miscellaneous;
using WebAPIClient.SerializerDeserializer;

namespace WebAPIClient.Tests
{
    public class Test
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

        public Test()
        {
            SFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\smallFull.json"));
            BFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\bigFull.json"));
            SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\smallOptimized.json"));
            BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\bigOptimized.json"));
            mpBytes1 = MessagePackSerializer.Serialize(SFM);
            mpBytes2 = MessagePackSerializer.Serialize(SOM);
            mpBytes3 = MessagePackSerializer.Serialize(BFM);
            mpBytes4 = MessagePackSerializer.Serialize(BOM);
            _req = new APICalls("http://localhost:32872/values");
        }
        public async Task Test_SFM()
        {
            var response = await _req.Post(mpBytes1, "/SFM");
            Console.WriteLine(response);
        }
        public async Task Test_BFM()
        {
            var response = await _req.Post(mpBytes3, "/BFM");
            Console.WriteLine(response);
        }
        public async Task Test_SOM()
        {
            var response = await _req.Post(mpBytes2, "/SOM");
            Console.WriteLine(response);
        }
        public async Task Test_BOM()
        {
            var response = await _req.Post(mpBytes4, "/BOM");
            Console.WriteLine(response);
        }


    }
}
