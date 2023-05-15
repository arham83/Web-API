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
    [Serializable]
    public class FullMessage
    {
        [Key(0)]
        public List<StructureDefinition> Header { get; set; }
        [Key(1)]
        public List<List<string>> Rows { get; set; }
    }

    [ProtoContract]
    [MessagePackObject]
    [Serializable]

    // Manager or Security Type, Headers should be dynamic 
    // as they doesn't be same all the time 
    public class StructureDefinition
    {
        [Key(0)]
        [ProtoMember(1)]
        public string Name { get; set; }
        [Key(1)]
        [ProtoMember(2)]
        public int Type { get; set; }
        [Key(2)]
        [ProtoMember(3)]
        public bool? IsList { get; set; }
        [Key(3)]
        [ProtoMember(4)]
        public bool? IsNullable { get; set; }
        [Key(4)]
        [ProtoMember(5)]
        public string Format { get; set; }
        [Key(5)]
        [ProtoMember(6)]
        public int? Aggregation { get; set; }
        [Key(6)]
        [ProtoMember(7)]
        public string Labels { get; set; }
    }
}
