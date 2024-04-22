using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeParameterListDto:IDto
    {
        public List<TypeParameterList> typeParameterLists { get; set; }
        public Guid? psiProcessDataPES2L2 { get; set; }
        public Guid? psiProcessStateL22PES { get; set; }
        public Guid? psiTypeInputMat { get; set; }      
        public Guid? psiTypeOutputMat { get; set; }
        public Guid? psiTypeProcessInstructions { get; set; }
        public Guid? psiTypeOutputMatTarget { get; set; }
        public Guid? psiGeneralAckPES2L2 { get; set; }
    }
}