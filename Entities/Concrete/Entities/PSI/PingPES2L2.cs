using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI
{
    public class PingPES2L2
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
