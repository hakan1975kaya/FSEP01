using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.UserRole;
using Entities.Concrete.Entities.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserRoleDal : EFEntityRepositoryBase<FSEP01Context, UserRole>, IUserRoleDal
    {
        public async Task<List<UserRoleDto>> Search(FilterDto filterDto)
        {
            using (var context = new FSEP01Context())
            {
                var data = from ur in context.UserRoles
                           join u in context.Users on ur.UserId equals u.Id
                           join r in context.Roles on ur.RoleId equals r.Id
                           where ur.IsActive == true &&
                           (ur.Optime.ToString().Contains(filterDto.Filter) ||
                           u.RegistrationNumber.ToString().Contains(filterDto.Filter) ||
                           u.FirstName.Contains(filterDto.Filter) ||
                           u.LastName.Contains(filterDto.Filter))
                           select new UserRoleDto
                           {
                               Id = ur.Id,
                               Optime = ur.Optime,
                               IsActive = ur.IsActive,
                               UserId = u.Id,
                               RegistrationNumber = u.RegistrationNumber,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               RoleId = r.Id,
                               RoleName = r.RoleName
                           };

                return data.ToList();
            }
        }
    }
}
