using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PSI
{
    public class GeneralAckPES2L2 : IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public string AckState { get; set; }
        public string InfoCode { get; set; }
        public string InfoText { get; set; }
        public string TelegramSeqNo { get; set; }
        public decimal CountParameter { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}


