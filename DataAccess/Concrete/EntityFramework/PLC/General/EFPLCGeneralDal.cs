using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PLC.General;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PLC.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.PLC.General
{
    public class EFPLCGeneralDal : EFEntityRepositoryBase<FSEP01Context, PLCGeneral>, IPLCGeneralDal
    {
    }
}
