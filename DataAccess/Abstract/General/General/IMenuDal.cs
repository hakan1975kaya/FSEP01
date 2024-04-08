﻿using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General.General
{
    public interface IMenuDal : IEntityRepositoryBase<Menu>
    {
    }
}
