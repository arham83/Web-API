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
            
            var summary2 = BenchmarkRunner.Run<BenchMarkMessagePack>();

            Console.ReadLine();
        }
    }
}
