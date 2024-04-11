using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class TypeProcessInstructions : IDto
    {
        public TypeInputMat InputMat { get; set; }
        public decimal CountOutputMat { get; set; }
        public List<TypeOutputMatTarget> OutputMatList { get; set; }
        public decimal CountProdParameter { get; set; }
        public List<TypeParameterList> ProdParameterList { get; set; }
    }
}
