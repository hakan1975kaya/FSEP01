using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class PSITypeInputMatCoord : IEntity
    {
        public Guid Id { get; set; }
        public Guid PSITypeOutputMatTarget { get; set; }
        public decimal OutputMatStartX { get; set; }
        public decimal OutputMatEndX { get; set; }
        public decimal OutputMatStartY { get; set; }
        public decimal OutputMatEndY { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}




