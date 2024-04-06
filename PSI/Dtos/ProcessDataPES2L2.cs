using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class ProcessDataPES2L2:IDto
    {
        public TypeHeader Header { get; set; }
        public TypeTimeStamp EventTime { get; set; }
        public string EventCode { get; set; }
        public string LineId { get; set; }
        public string LineSequenceId { get; set; }
        public decimal CountLineSeqParameter { get; set; }
        public decimal CountProcessInstructions { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
