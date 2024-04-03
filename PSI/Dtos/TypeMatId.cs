using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class TypeMatId : IDto
    {
        public string GlobalId { get; set; }
        public string LocalId { get; set; }
        public string InternalId { get; set; }
    }
}

