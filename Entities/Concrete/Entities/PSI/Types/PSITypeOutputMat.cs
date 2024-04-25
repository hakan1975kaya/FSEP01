using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class PSITypeOutputMat : IEntity
    {
        public Guid Id { get; set; }
        public Guid PSIProdReportL22PES { get; set; }
        public Guid MatId { get; set; }
        public string? KindOfOutput { get; set; }
        public Guid? ProdStart { get; set; }
        public Guid? ProdEnd { get; set; }
        public decimal? ProdDuration { get; set; }
        public decimal? CountOutputParameter { get; set; }
        public decimal? CountOutputDefects { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}


