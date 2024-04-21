using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class PSITypeParameterList : IEntity
    {
        public Guid Id { get; set; }
        public Guid? PSIProcessDataPES2L2 { get; set; }
        public Guid? PSIProcessStateL22PES { get; set; }
        public Guid? PSITypeInputMat { get; set; }
        public Guid? PSITypeOutputMat { get; set; }
        public Guid? PSITypeProcessInstructions { get; set; }
        public Guid? PSITypeOutputMatTarget { get; set; }
        public Guid? PSIGeneralAckPES2L2 { get; set; }
        public string ParameterName { get; set; }
        public string? ParameterValueString { get; set; }
        public decimal? ParameterValueNumber { get; set; }
        public Guid? ParameterDate { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}








