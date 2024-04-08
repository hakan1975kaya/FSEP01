using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class ParameterHeadTailScrap:IEntity
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public short? ScrapValue { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
