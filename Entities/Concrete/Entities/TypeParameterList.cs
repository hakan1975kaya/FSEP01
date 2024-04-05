using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class TypeParameterList:IEntity
    {
        public Guid Id { get; set; }
        public Guid ProcessStateL22PESId { get; set; }
        public Guid TypeInputMatId { get; set; }
        public Guid TypeOutputMatId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValueString { get; set; }
        public decimal ParameterValueNumber { get; set; }
        public Guid ParameterDate { get; set; }
        public string UnitOfMeasurement { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}





