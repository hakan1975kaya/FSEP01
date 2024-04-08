using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Types
{
    public class TypeOutputMat : IDto
    {
        public TypeMatId MatId { get; set; }
        public string KindOfOutput { get; set; }
        public TypeTimeStamp ProdStart { get; set; }
        public TypeTimeStamp ProdEnd { get; set; }
        public decimal ProdDuration { get; set; }
        public decimal CountOutputParameter { get; set; }
        public List<TypeParameterList> ParameterList { get; set; }
        public decimal CountOutputDefects { get; set; }
        public List<TypeDefectList> OutputDefectList { get; set; }
    }
}




