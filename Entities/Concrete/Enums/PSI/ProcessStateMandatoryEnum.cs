using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum ProcessStateMandatoryEnum
    {
        None = 0,
        CHARGED = 1,//None-->Hiçbiri
        DISPLACED = 2,//FLAGCOMPLETE (Y/N),For partial displace (FLAGCOMPLETE = ‘N’): DISPLACE_ENTRY_LENGTH-->BAYRAK TAMAMLANDI (E/H), Kısmi yer değiştirmek için (FLAGCOMPLETE = 'N'): GİRİŞ UZUNLUĞUNU DEĞİŞTİRİN
        WEIGHED = 3,//EXIT_FOIL_WEIGHT--> ÇIKIŞ FOLYO AĞIRLIĞI
        SCRAPPED = 4,//SCRAP_LENGTH, SCRAPCODE (HEAD or TAIL)-->HURDA UZUNLUĞU, HURDA KODU (KAFA veya KUYRUK)
        LOCATED = 5,//FIELD – IDs of the actual storage position-->FIELD – Gerçek depolama konumunun kimlikleri
        STAGING = 6,//None-->Hiçbiri
        INSPECTED = 7//None-->Hiçbiri

    }
}
