using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePack;

namespace WebAPIServer.MessageStructure
{
    [MessagePackObject]
    public class SampleMessage
    {
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public string Name { get; set; }
    }
}
