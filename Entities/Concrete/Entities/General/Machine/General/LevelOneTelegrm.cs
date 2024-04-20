using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.General
{
    public class LevelOneTelegrm : IEntity
    {
        public Guid Id { get; set; }
        public string? LineId { get; set; }//FSLT01
        public string? TelegramType { get; set; }//ProcessData
        public DateTime? TelegramOccurrenceTime { get; set; }//2023-06-25 08:48:31
        public DateTime? TelegramSendTime { get; set; }//2023-06-25 08:48:32
        public string? Payload { get; set; }//2100,1,123080328.01 ,2.72,1920.00,0.0600,680,750,999999,750,999999,345.03,345.06,300,100,20,10,100,94,87,87,87,87,87,87,87,87,100,100,100,100,100,100,100,100,100,100,100,94,87,87,87,87,87,87,87,87,100,100,100,100,100,100,100,100,100,100,150,700,700,700,700,700,700,700,700,700,26.0,0.55,0,1,0,1,0,26.0,0.55,0,1,0,1,0,1,6.1,6.0,75.0,75.0,444,444,100,800,0,100,800,0,1,0,0,0,50,25,25,600,241.05,242.65,245.96,245.96
        public string? TelegramContent { get; set; }//2100,1,123080328.01,2.72,1920.00,0.0600,680,750,999999,750,999999,345.03,345.06,300,100,20,10,100,94,87,87,87,87,87,87,87,87,100,100,100,100,100,100,100,100,100,100,100,94,87,87,87,87,87,87,87,87,100,100,100,100,100,100,100,100,100,100,150,700,700,700,700,700,700,700,700,700,26.0,0.55,0,1,0,1,0,26.0,0.55,0,1,0,1,0,1,6.1,6.0,75.0,75.0,444,444,100,800,0,100,800,0,1,0,0,0,50,25,25,600,241.05,242.65,245.96,245.96
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
