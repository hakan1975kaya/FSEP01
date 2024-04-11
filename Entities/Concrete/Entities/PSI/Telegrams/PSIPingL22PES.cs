using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Telegrams
{
    public class PSIPingL22PES : IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

