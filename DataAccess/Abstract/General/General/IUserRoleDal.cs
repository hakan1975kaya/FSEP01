﻿using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.UserRole;
using Entities.Concrete.Entities.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General.General
{
    public interface IUserRoleDal : IEntityRepositoryBase<UserRole>
    {
        public Task<List<UserRoleDto>> Search(FilterDto filterDto);
    }
}
