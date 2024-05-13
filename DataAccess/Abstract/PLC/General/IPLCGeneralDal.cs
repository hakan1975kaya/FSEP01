using Core.DataAccess.Abstract;
using Entities.Concrete.Entities.PLC.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.PLC.General
{
    public interface IPLCGeneralDal : IEntityRepositoryBase<PLCGeneral>
    {
    }
}
