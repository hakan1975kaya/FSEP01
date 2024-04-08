using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Telegrams
{
    public class PingPES2L2 : IDto
    {
        public TypeHeader Header { get; set; }
    }
}
