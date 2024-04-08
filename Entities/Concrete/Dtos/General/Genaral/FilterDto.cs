using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.General.Genaral
{
    public class FilterDto : IDto
    {
        public string Filter { get; set; }
    }
}
