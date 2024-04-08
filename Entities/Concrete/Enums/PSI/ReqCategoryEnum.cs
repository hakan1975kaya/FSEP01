using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PSI
{
    public enum ReqCategoryEnum
    {
        none = 0,
        PG = 1,//Program: the Foil schedule is requested. Only Foil IDs will be sent in a response telegram.-->Program: Folyo programı talep edilir. Yanıt telgrafında yalnızca Folyo Kimlikler gönderilecektir.
        MAT = 2//Material: individual process data for one Foil is requested. Full process data will be sent for the specified foil.-->Malzeme: Bir Folyo için ayrı proses verileri talep edilmektedir. Belirtilen folyo için tam işlem verileri gönderilecektir.
    }
}
