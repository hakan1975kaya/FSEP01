﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class ParameterBasicData : IEntity
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public short? Acceleration { get; set; }
        public short? Deceleration { get; set; }
        public short? FastStop { get; set; }
        public short? JogSpeed { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
