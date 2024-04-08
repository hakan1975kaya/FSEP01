﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class TypeProcessInstructions : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputMat { get; set; }
        public decimal CountOutputMat { get; set; }
        public decimal CountProdParameter { get; set; }
        public decimal Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
