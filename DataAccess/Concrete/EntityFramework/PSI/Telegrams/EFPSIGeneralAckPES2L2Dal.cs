﻿using Core.DataAccess.Concrete.EntityFramework;
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
    public class EFPSIGeneralAckPES2L2Dal : EFEntityRepositoryBase<FSEP01Context, PSIGeneralAckPES2L2>, IPSIGeneralAckPES2L2Dal
    {
    }
}
