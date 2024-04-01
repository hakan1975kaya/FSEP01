using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserDal : EFEntityRepositoryBase<FSEPContext, User>, IUserDal
    {
        public async Task<List<Demand>> GetDemandsByUserId(Guid userId)
        {
            using (var context = new FSEPContext())
            {
                var result = from u in context.Users
                             join ur in context.UserRoles on u.Id equals ur.UserId
                             join rd in context.RoleDemands on ur.RoleId equals rd.RoleId
                             join d in context.Demands on rd.DemandId equals d.Id
                             where u.IsActive == true &&
                             ur.IsActive == true &&
                             rd.IsActive == true &&
                             d.IsActive == true &&
                             u.Id == userId
                             select new Demand
                             {
                                 Id = d.Id,
                                 DemandName = d.DemandName,
                                 IsActive = d.IsActive,
                                 Optime = d.Optime

                             };

                return result.OrderBy(x=>x.DemandName).ToList();
            }
        }

        public async Task<List<Menu>> GetMenusByUserId(Guid userId)
        {
            using (var context = new FSEPContext())
            {
                var result = from u in context.Users
                             join ur in context.UserRoles on u.Id equals ur.UserId
                             join rm in context.RoleMenus on ur.RoleId equals rm.RoleId
                             join m in context.Menus on rm.MenuId equals m.Id
                             where u.IsActive == true &&
                             ur.IsActive == true &&
                             rm.IsActive == true &&
                             m.IsActive == true &&
                             u.Id == userId
                             select new Menu
                             {
                                 Id = m.Id,
                                 MenuName = m.MenuName,
                                 Description = m.Description,
                                 Path = m.Path,
                                 MenuOrder = m.MenuOrder,
                                 IsActive = m.IsActive,
                                 Optime = m.Optime

                             };

                return result.OrderBy(x=>x.MenuOrder).ToList();
            }
        }
    }
}
