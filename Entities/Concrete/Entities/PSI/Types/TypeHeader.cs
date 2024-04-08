using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI.Types
{
    public class TypeHeader : IEntity
    {
        public Guid Id { get; set; }
        public string TelegramType { get; set; }
        public string TelegramLength { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string TelegramSeqNo { get; set; }
        public Guid TimeStamp { get; set; }
        public string AckReq { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}






