using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Enums
{
    public enum ReceivingTelegramTypeEnum
    {
        none = 0,
        RequestProcessDataL22PES = 1,//Process data request-->Veri talebini işle
        ProcessStateL22PES = 2,//Process state data-->İşlem durumu verileri
        ProdReportL22PES = 3,//Production report of a Foil-->Folyo üretim raporu
        PingL22PES = 4,//Health check telegram-->Sağlık kontrolü telgrafı 
        PingAckL22PES = 5//Ping acknowledge-->Ping'i onayla
    }
}
