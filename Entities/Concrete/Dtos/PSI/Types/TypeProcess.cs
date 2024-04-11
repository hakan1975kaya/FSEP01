using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class TypeProcess : IDto
    {
        public string ProcessId { get; set; }
        public string ProcessPhase { get; set; }
    }
}

