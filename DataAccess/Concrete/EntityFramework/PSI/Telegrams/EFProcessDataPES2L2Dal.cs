using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PSI.Telegrams;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PSI.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.PSI.Telegrams
{
    public class EFProcessDataPES2L2Dal : EFEntityRepositoryBase<FSEP01Context, ProcessDataPES2L2>, IProcessDataPES2L2Dal
    {
    }
}
