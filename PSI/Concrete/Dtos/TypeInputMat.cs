using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete.Dtos
{
    public class TypeInputMat : IDto
    {
        public TypeMatId MatId { get; set; }
        public string FlagConsumed { get; set; }
        public string UsageOfInput { get; set; }
        public decimal CountInputParameter { get; set; }
        public TypeParameterList ParameterList { get; set; }
        public decimal CountInputDefects { get; set; }
        public TypeDefectList InputDefectList { get; set; }
    }
}


