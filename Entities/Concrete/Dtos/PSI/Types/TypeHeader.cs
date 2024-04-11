using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class TypeHeader : IDto
    {
        public string TelegramType { get; set; }
        public string TelegramLength { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string TelegramSeqNo { get; set; }
        public TypeTimeStamp TimeStamp { get; set; }
        public string AckReq { get; set; }
    }
}
