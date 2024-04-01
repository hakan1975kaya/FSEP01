﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Demand> demands,List<Menu> menus);
    }
}
