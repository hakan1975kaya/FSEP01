using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilDefect : IEntity//Giriş Bobini Kusur
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public int ProcedureInstructionRequestNumber { get; set; }//4298
        public int SquenceNumber { get; set; }//3
        public string? LocalId { get; set; }//121071008
        public string? DefectCode { get; set; }//Kusur Kodu KISTIRMA
        public string? DefectBlocking { get; set; }//N
        public string? DefectSeverity { get; set; }//Kusur Önem Derecesi M
        public string? DefectComment { get; set; }//2130 CAP USTU GIRSTEN GELME KISTIRMA IZLERI VAR
        public float? DefectLengthStartPosition { get; set; }//0
        public float? DefectLength { get; set; }//58877
        public float? DefectWidthStartPosition { get; set; }//0
        public float? DefectWidth { get; set; }//Kusur Genişliği 1710
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
