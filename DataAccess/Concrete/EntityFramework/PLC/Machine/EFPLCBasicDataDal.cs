﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PLC.Machine;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PLC.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.PLC.Machine
{
    public class EFPLCBasicDataDal:EFEntityRepositoryBase<FSEP01Context, PLCBasicData>, IPLCBasicDataDal
    {
    }
}
