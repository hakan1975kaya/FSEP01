using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Defination : IEntity
    {
        public Guid Id { get; set; }
        public int MessageId { get; set; }
        public string TelegramType { get; set; }
        public string? TelegramLength { get; set; }
        public string? Sender { get; set; }
        public string? Reciever { get; set; }
        public int? TelegramSeqNumber { get; set; }
        public DateTime? TimeStapmp { get; set; }
        public string? AckReq { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
