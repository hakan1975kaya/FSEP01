using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeProcessInstructionsDto:IDto
    {
        public List<TypeProcessInstructions> typeProcessInstructions { get; set; }
        public Guid psiProcessDataPES2L2 { get; set; }
    }
}
