using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum ReceivingTelegramTypes
    {
        none = 0,
        RequestProcessDataL22PES = 1,//
        ProcessStateL22PES = 2,
        ProdReportL22PES = 3,
        PingL22PES = 4,
        PingAckL22PES = 5
    }
}
