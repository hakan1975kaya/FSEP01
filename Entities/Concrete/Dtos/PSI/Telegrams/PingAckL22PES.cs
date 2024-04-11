using Core.Entities.Abstract;
using Entities.Concrete.Dtos.PSI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Telegrams
{
    public class PingAckL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public string TelegramSeqNo { get; set; }
    }
}





