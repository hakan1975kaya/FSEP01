using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class TypeInputMat : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProdReportL22PES { get; set; }
        public Guid MatId { get; set; }
        public string FlagConsumed { get; set; }
        public string UsageOfInput { get; set; }
        public decimal CountInputParameter { get; set; }
        public decimal CountInputDefects { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}








