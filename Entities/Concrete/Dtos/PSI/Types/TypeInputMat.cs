using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class TypeInputMat : IDto
    {
        public TypeMatId MatId { get; set; }
        public string FlagConsumed { get; set; }
        public string UsageOfInput { get; set; }
        public decimal CountInputParameter { get; set; }
        public List<TypeParameterList> ParameterList { get; set; }
        public decimal CountInputDefects { get; set; }
        public List<TypeDefectList> InputDefectList { get; set; }
    }
}


