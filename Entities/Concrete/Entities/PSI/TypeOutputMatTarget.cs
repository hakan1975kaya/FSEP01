using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI
{
    public class TypeOutputMatTarget : IEntity
    {
        public Guid Id { get; set; }
        public Guid TypeProcessInstructions { get; set; }
        public Guid MatId { get; set; }
        public decimal CountOutputParameter { get; set; }
        public decimal CountInputMatRelation { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

