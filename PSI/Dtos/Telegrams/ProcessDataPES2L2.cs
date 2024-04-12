using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Telegrams
{
    public class ProcessDataPES2L2 : IDto
    {
        public TypeHeader Header { get; set; }
        public TypeTimeStamp EventTime { get; set; }
        public string EventCode { get; set; }
        public string LineId { get; set; }
        public string LineSequenceId { get; set; }
        public decimal CountLineSeqParameter { get; set; }
        public List<TypeParameterList> LineSeqParameterList { get; set; }
        public decimal CountProcessInstructions { get; set; }
        public List<TypeProcessInstructions> ProcessInstructions { get; set; }
    }
}
