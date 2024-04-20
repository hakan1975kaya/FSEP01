﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class TramRoll : IEntity//Tramvay Rulosu
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public string? RollNumber { get; set; }
        public decimal? RollDiameter { get; set; }
        public string? GroupName { get; set; }
        public string? RollName { get; set; }
        public short? TramCount { get; set; }
        public string? Status { get; set; }
        public string? Location { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
