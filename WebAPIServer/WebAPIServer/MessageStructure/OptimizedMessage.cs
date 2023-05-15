using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;

namespace WebAPIServer.MessageStructure
{
    [MessagePackObject]
    [Serializable]
    public class OptimizedMessage
    {
        [Key(0)]
        public List<StructureDefinition> Header { get; set; }
        [Key(1)]
        public string Rowdata { get; set; }
    }
}
