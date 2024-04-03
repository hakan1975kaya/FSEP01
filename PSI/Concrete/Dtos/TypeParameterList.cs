using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete.Dtos
{
    public class TypeParameterList : IDto
    {
        public string ParameterName { get; set; }
        public string ParameterValueString { get; set; }
        public decimal ParameterValueNumber { get; set; }
        public TypeTimeStamp ParameterDate { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}



