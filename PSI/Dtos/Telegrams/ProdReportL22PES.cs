using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Telegrams
{
    public class ProdReportL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public TypeTimeStamp? EventTime { get; set; }
        public string? LineId { get; set; }
        public string? ProdCode { get; set; }
        public decimal? CountInputMat { get; set; }
        public List<TypeInputMat>? InputMat { get; set; }
        public decimal? CountOutputMat { get; set; }
        public List<TypeOutputMat>? OutputMat { get; set; }
    }
}


