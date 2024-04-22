using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeDefectListDto : IDto
    {
        public List<TypeDefectList> typeDefectLists { get; set; }
        public Guid? psiTypeDefectActionList { get; set; }
        public Guid? psiTypeInputMat { get; set; }
        public Guid? psiTypeOutputMat { get; set; }
    }
}