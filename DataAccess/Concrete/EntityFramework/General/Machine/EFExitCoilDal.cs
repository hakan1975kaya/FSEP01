﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.General;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine
{
    public class EFExitCoilDal:EFEntityRepositoryBase<FSEP01Context,ExitCoil>,IExitCoilDal
    {
    }
}
