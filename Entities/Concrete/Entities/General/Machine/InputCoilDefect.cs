﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilDefect : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public int ProcedureInstructionRequestNumber { get; set; }
        public int SquenceNumber { get; set; }
        public string? LocalId { get; set; }
        public string? DefectCode { get; set; }
        public string? DefectBlocking { get; set; }
        public string? DefectSeverity { get; set; }
        public string? DefectComment { get; set; }
        public float? DefectLengthStartPosition { get; set; }
        public float? DefectLength { get; set; }
        public float? DefectWidthStartPosition { get; set; }
        public float? DefectWidth { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
