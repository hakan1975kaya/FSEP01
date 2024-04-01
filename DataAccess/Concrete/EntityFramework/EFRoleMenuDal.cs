using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Dtos.RoleMenu;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRoleMenuDal : EFEntityRepositoryBase<FSEPContext, RoleMenu>, IRoleMenuDal
    {
        public async Task<List<RoleMenuDto>> Search(FilterDto filterDto)
        {
            using (var context = new FSEPContext())
            {
                var data = from rm in context.RoleMenus
                           join r in context.Roles on rm.RoleId equals r.Id
                           join m in context.Menus on rm.MenuId equals m.Id
                           where rm.IsActive == true &&
                           (rm.Optime.ToString().Contains(filterDto.Filter) ||
                           r.RoleName.Contains(filterDto.Filter) ||
                           m.MenuName.Contains(filterDto.Filter) ||
                           m.Path.Contains(filterDto.Filter) ||
                           m.Description.Contains(filterDto.Filter) ||
                           m.MenuOrder.ToString().Contains(filterDto.Filter))
                           select new RoleMenuDto
                           {
                               Id = rm.Id,
                               Optime = rm.Optime,
                               IsActive = rm.IsActive,
                               RoleId = r.Id,
                               RoleName = r.RoleName,
                               MenuId = m.Id,
                               MenuName = m.MenuName,
                               Path = m.Path,
                               Description = m.Description,
                               MenuOrder = m.MenuOrder
                           };

                return data.ToList();

            }
        }
    }
}
