using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Enums
{
    public enum KindOfOutputMandatoryEnum
    {
        None = 0,
        MAIN = 1,//EXIT_THICKNESS_ACT_PASS; FLAGCOMPLETE-->ÇIKIŞ KALINLIĞI ACT GEÇİŞİ; BAYRAK TAMAMLANDI
        SCRAP = 2//SCRAPCODE (HEAD / TAIL) -->KAZIMA KODU (KAFA / KUYRUK)

    }
}
