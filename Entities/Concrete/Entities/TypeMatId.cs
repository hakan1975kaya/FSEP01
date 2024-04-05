using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class TypeMatId:IEntity
    {
        public Guid Id { get; set; }
        public string GlobalId { get; set; }
        public string InternalId { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
