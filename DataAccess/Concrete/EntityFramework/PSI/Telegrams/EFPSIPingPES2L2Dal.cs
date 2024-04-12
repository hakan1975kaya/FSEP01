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
    public class EFPSIPingPES2L2Dal : EFEntityRepositoryBase<FSEP01Context, PSIPingPES2L2>, IPSIPingPES2L2Dal
    {
    }
}
