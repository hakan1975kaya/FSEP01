using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class RequestProcessDataL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public TypeTimeStamp EventTime { get; set; }
        public string LineId { get; set; }
        public string ReqType { get; set; }
        public string ReqCategory { get; set; }
        public string ReqKey { get; set; }
        public TypeMatId MatId { get; set; }
        public string EventCode { get; set; }
        public string Remark { get; set; }
    }
}

