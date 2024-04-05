using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class TypeDefectActionList : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProcessStateL22PESId { get; set; }
        public string Action { get; set; }
        public decimal CountDefects { get; set; }
        public Guid OutputDefectList { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}






