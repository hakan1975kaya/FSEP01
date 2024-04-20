
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class LevelThreeTelegram:IEntity
    {
        public Guid Id { get; set; }
        public string? LineId { get; set; }//FSLT01
        public string? TelegramType { get; set; }//ProcessState
        public DateTime? TelegramOccurrenceTime { get; set; }//2023-06-04 17:34:18
        public DateTime? TelegramSendTime { get; set; }//2023-06-04 17:34:21
        public string? Payload { get; set; }//467#ProcessStateL22PES  467  FSLT01  PSI  11164 2023-06-04 17:34:18ALWAUT2023-06-04 17:34:18FSLT01  123060226.01 CHARGED  0   0
        public string? TelegramContent { get; set; }//467#ProcessStateL22PES,467,FSLT01,PSI,11164,2023-06-04 17:34:18,ALW,AUT,2023-06-04 17:34:18,FSLT01,,,,123060226.01,,CHARGED,,00
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
