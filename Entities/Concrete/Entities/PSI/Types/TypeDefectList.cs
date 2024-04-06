using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class TypeDefectList : IEntity
    {
        public Guid Id { get; set; }
        public Guid? TypeDefectActionList { get; set; }
        public Guid? TypeInputMat { get; set; }
        public Guid? TypeOutputMat { get; set; }
        public string DefectCode { get; set; }
        public string DefectBlocking { get; set; }
        public string DefectSeverity { get; set; }
        public string DefectComment { get; set; }
        public decimal DefectLengthStartPos { get; set; }
        public decimal DefectLength { get; set; }
        public decimal DefectWidthStartPos { get; set; }
        public decimal DefectWidth { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}











