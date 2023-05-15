using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using ProtoBuf;

namespace WebAPIClient.Message
{
    [MessagePackObject]
    [ProtoContract]
    [Serializable]
    public class OptimizedMessage
    {
        [Key(0)]
        [ProtoMember(1)]
        public List<StructureDefinition> Header { get; set; }
        [Key(1)]
        [ProtoMember(2)]
        public string Rowdata { get; set; }
    }
}
