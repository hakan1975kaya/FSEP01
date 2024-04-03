using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete.Dtos
{
    public class ProdReportL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public TypeTimeStamp EventTime { get; set; }
        public string LineId { get; set; }
        public string ProdCode { get; set; }
        public decimal CountInputMat { get; set; }
        public TypeInputMat InputMat { get; set; }
        public decimal CountOutputMat { get; set; }
        public TypeOutputMat OutputMat { get; set; }
    }
}


