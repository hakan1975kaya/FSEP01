﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class PSITypeDefectList : IEntity
    {
        public Guid Id { get; set; }
        public Guid? PSITypeDefectActionList { get; set; }
        public Guid? PSITypeInputMat { get; set; }
        public Guid? PSITypeOutputMat { get; set; }
        public string? DefectCode { get; set; }
        public string? DefectBlocking { get; set; }
        public string? DefectSeverity { get; set; }
        public string? DefectComment { get; set; }
        public decimal? DefectLengthStartPos { get; set; }
        public decimal? DefectLength { get; set; }
        public decimal? DefectWidthStartPos { get; set; }
        public decimal? DefectWidth { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}








