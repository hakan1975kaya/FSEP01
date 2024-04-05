using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class TypeDefectActionList : IDto
    {
        public string Action { get; set; }
        public string CountDefects { get; set; }
        public List<TypeDefectList> OutputDefectList { get; set; }
    }
}


