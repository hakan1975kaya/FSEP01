using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.Parameters
{
    public class ParameterSpeedCharacteristic : IEntity
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public short? DiameterOne { get; set; }
        public short? DiameterTwo { get; set; }
        public short? DiameterThree { get; set; }
        public short? DiameterFour { get; set; }
        public short? DiameterFive { get; set; }
        public short? DiameterSix { get; set; }
        public short? DiameterSeven { get; set; }
        public short? DiameterEight { get; set; }
        public short? DiameterNine { get; set; }
        public short? DiameterTen { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
