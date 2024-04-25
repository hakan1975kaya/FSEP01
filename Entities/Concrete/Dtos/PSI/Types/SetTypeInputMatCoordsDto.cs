using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeInputMatCoordsDto:IDto
    {
        public List<TypeInputMatCoord> typeInputMatCoords { get; set; }
        public Guid psiTypeOutputMatTarget { get; set; }
    }
}
