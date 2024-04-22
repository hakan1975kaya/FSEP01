using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeInputMatDto : IDto
    {
        public TypeInputMat typeInputMat { get; set; }
        public Guid psiTypeInputMatId { get; set; }
        public Guid psiTypeMatId { get; set; }
        public Guid? psiTypeProcessInstructions { get; set; }
        public Guid? psiProdReportL22PES { get; set; }
    }
}