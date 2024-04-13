using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Enums
{
    public enum ProdCodeEnum
    {
        none=0,
        NORMAL= 1//Normal production.The attribute KindOfOutput in TypeOutput-Mat can only have the values ‘MAIN’ or ‘SCRAP’-->Normal üretim.TypeOutput Mat'taki KindOfOutput özelliği yalnızca 'MAIN' veya 'SCRAP' değerlerine sahip olabilir
    }
}
