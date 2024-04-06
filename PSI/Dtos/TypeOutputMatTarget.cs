using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class TypeOutputMatTarget : IDto
    {
        public TypeMatId MatId { get; set; }
        public decimal CountOutputParameter { get; set; }
        public List<TypeParameterList> ParameterList { get; set; }
        public decimal CountInputMatRelation { get; set; }
        public List<TypeInputMatCoord> MatRelationList { get; set; }
    }
}
