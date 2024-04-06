using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Dtos.RoleMenu;
using Entities.Concrete.Entities.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoleMenuDal:IEntityRepositoryBase<RoleMenu>
    {
        public Task<List<RoleMenuDto>> Search(FilterDto filterDto);
    }
}
