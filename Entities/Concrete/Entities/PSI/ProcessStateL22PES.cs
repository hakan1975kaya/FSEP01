using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI
{
    public class ProcessStateL22PES : IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public string Eventmode { get; set; }
        public Guid EventTime { get; set; }
        public string LineId { get; set; }
        public Guid Process { get; set; }
        public Guid MatId { get; set; }
        public string EventCode { get; set; }
        public string SubLine { get; set; }
        public decimal CountEventParameter { get; set; }
        public decimal CountDefectActions { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}



