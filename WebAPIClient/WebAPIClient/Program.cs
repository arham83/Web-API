using BenchmarkDotNet.Running;
using MessagePack;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIClient.BenchMarkIT;
using WebAPIClient.Message;
using WebAPIClient.Miscellaneous;
using WebAPIClient.SerializerDeserializer;

namespace WebAPIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            APICalls req = new APICalls("http://localhost:32872/values");

           
           SampleMessage sm = new SampleMessage()
            {
                Id = 306,
                Name = "Arham"
            };
            var data = MessagePackSerializer.Serialize(sm);

            var response = await req.Post(data,"/SM");
            var SFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\smallFull.json"));
            var BFM = JsonHandler.DeserializeJson<FullMessage>(Misc.GetPath(@"SampleMessages\bigFull.json"));
            var SOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\smallOptimized.json"));
            var BOM = JsonHandler.DeserializeJson<OptimizedMessage>(Misc.GetPath(@"SampleMessages\bigOptimized.json"));
            var mpBytes1 = MessagePackSerializer.Serialize(SFM);
            var mpBytes2 = MessagePackSerializer.Serialize(SOM);
            var mpBytes3 = MessagePackSerializer.Serialize(BFM);
            var mpBytes4 = MessagePackSerializer.Serialize(BOM);

            Console.WriteLine("SFM" + mpBytes1.Length);
            Console.WriteLine("SOM" + mpBytes2.Length);
            Console.WriteLine("BFM" + mpBytes3.Length);
            Console.WriteLine("BOM" + mpBytes4.Length);
            //var summary2 = BenchmarkRunner.Run<BenchMarkMessagePack>();

            Console.ReadLine();
        }
    }
}
