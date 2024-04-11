using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class PSITypeProcess : IEntity
    {
        public Guid Id { get; set; }
        public string ProcessId { get; set; }
        public string ProcessPhase { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}


