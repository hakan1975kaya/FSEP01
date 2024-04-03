﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete.Dtos
{
    public class TypeOutputMat : IDto
    {
        public TypeMatId MatId { get; set; }
        public string KindOfOutput { get; set; }
        public TypeTimeStamp ProdStart { get; set; }
        public TypeTimeStamp ProdEnd { get; set; }
        public decimal ProdDuration { get; set; }
        public decimal CountOutputParameter { get; set; }
        public TypeParameterList ParameterList { get; set; }
        public decimal CountOutputDefects { get; set; }
        public TypeDefectList OutputDefectList { get; set; }
    }
}




