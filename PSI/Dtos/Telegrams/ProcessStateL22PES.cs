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
    public class ProcessStateL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public string? Eventmode { get; set; }
        public TypeTimeStamp? EventTime { get; set; }
        public string? LineId { get; set; }
        public TypeProcess? Process { get; set; }
        public TypeMatId? MatId { get; set; }
        public string? EventCode { get; set; }
        public string? SubLine { get; set; }
        public decimal? CountEventParameter { get; set; }
        public List<TypeParameterList>? ParameterList { get; set; }
        public decimal? CountDefectActions { get; set; }
        public List<TypeDefectActionList>? DefectList { get; set; }
    }
}







