using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Defination : IEntity//Tanum
    {
        public Guid Id { get; set; }
        public int MessageId { get; set; }//8650
        public string TelegramType { get; set; }//ProcessDataPES2L2
        public string? TelegramLength { get; set; }
        public string? Sender { get; set; }//PSI
        public string? Reciever { get; set; }//FSLT01
        public int? TelegramSequenceNumber { get; set; }//2475869
        public DateTime? TimeStamp { get; set; }//2023-06-02 23:47:35
        public string? AckReq { get; set; }// NEG
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

						 