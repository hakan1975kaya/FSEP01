using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class ProdReportL22PES : IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public Guid EventTime { get; set; }
        public string LineId { get; set; }
        public string ProdCode { get; set; }
        public decimal CountInputMat { get; set; }
        public decimal CountOutputMat { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}













