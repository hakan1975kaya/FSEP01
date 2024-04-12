using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Telegrams
{
    public class PSIProcessDataPES2L2 : IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public Guid EventTime { get; set; }
        public string EventCode { get; set; }
        public string LineId { get; set; }
        public string LineSequenceId { get; set; }
        public decimal CountLineSeqParameter { get; set; }
        public decimal CountProcessInstructions { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
