using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum StateEventCodeEnum
    {
        none = 0,
        CHARGED = 1,//a Foil is placed on the decoiler-->Açıcının üzerine bir Folyo yerleştirilir
        LOCATED = 2,//a Foil is moved to the exit position of the foil area-->a Folyo, folyo alanının çıkış konumuna hareket ettirilir
        DISPLACED = 3,//a Foil is partially or completely displaced from the mill during processing-->a Folyo işleme sırasında değirmenden kısmen veya tamamen yerinden çıkmış
        WEIGHED = 4,//Material weighed (separate weighing).-->Tartılan malzeme (ayrı tartım).
        SCRAPPED = 5,//Material scrapped (separate scrap booking on the preparation or inspection station).-->Hurdaya çıkan malzeme (hazırlık veya muayene istasyonunda ayrı hurda rezervasyonu).
        STAGING = 6//A new foil is requested by L2 system to be relocated for processing

    }
}
