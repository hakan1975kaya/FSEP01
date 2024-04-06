using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI
{
    public class TypeParameterList : IEntity
    {
        public Guid Id { get; set; }
        public Guid? ProcessDataPES2L2 { get; set; }
        public Guid? ProcessStateL22PES { get; set; }
        public Guid? TypeInputMat { get; set; }
        public Guid? TypeOutputMat { get; set; }
        public Guid? TypeProcessInstructions { get; set; }
        public Guid? TypeOutputMatTarget { get; set; }
        public Guid? GeneralAckPES2L2 { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValueString { get; set; }
        public decimal ParameterValueNumber { get; set; }
        public Guid ParameterDate { get; set; }
        public string UnitOfMeasurement { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}








