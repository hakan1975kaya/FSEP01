using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class ProcessStateL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public string Eventmode { get; set; }
        public TypeTimeStamp EventTime { get; set; }
        public string LineId { get; set; }
        public TypeProcess Process { get; set; }
        public TypeMatId MatId { get; set; }
        public string EventCode { get; set; }
        public string SubLine { get; set; }
        public decimal CountEventParameter { get; set; }
        public TypeParameterList ParameterList { get; set; }
        public decimal CountDefectActions { get; set; }
        public TypeDefectActionList DefectList { get; set; }
    }
}







