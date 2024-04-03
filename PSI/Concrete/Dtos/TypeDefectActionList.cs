using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Concrete.Dtos
{
    public class TypeDefectActionList : IDto
    {
        public string Action { get; set; }
        public string CountDefects { get; set; }
        public TypeDefectList OutputDefectList { get; set; }
    }
}


