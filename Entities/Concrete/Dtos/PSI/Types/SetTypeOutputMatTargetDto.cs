using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeOutputMatTargetDto:IDto
    {
        public List<TypeOutputMatTarget> typeOutputMatTargets { get; set; }
        public Guid psiTypeMatId { get; set; }
        public Guid psiTypeIProcessInstructions { get; set; }
    }
}
