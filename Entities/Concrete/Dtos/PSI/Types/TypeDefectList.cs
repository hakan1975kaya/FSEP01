using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class TypeDefectList : IDto
    {
        public string DefectCode { get; set; }
        public string DefectBlocking { get; set; }
        public string DefectSeverity { get; set; }
        public string DefectComment { get; set; }
        public decimal DefectLengthStartPos { get; set; }
        public decimal DefectLength { get; set; }
        public decimal DefectWidthStartPos { get; set; }
        public decimal DefectWidth { get; set; }
    }
}



