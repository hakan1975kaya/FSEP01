using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Types
{
    public class TypeInputMatCoord : IDto
    {
        public decimal? OutputMatStartX { get; set; }
        public decimal? OutputMatEndX { get; set; }
        public decimal? OutputMatStartY { get; set; }
        public decimal? OutputMatEndY { get; set; }
    }
}
