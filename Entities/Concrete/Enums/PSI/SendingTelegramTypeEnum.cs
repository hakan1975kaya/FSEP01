using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum SendingTelegramTypeEnum
    {
        None = 0,
        ProcessDataPES2L2 = 1,//Program data-->Program verisi
        GeneralAckPES2L2 = 2,//Application acknowledgment-->Başvuru onayı
        PingPES2L2 = 3,//Health check telegram-->Sağlık kontrolü telgrafı
        PingAckPES2L2 = 4//Ping acknowledge-->Ping'i onayla
    }
}
