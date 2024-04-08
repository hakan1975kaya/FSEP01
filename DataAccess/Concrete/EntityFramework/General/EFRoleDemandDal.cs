using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.General;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.RoleDemand;
using Entities.Concrete.Entities.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General
{
    public class EFRoleDemandDal : EFEntityRepositoryBase<FSEP01Context, RoleDemand>, IRoleDemandDal
    {
        public async Task<List<RoleDemandDto>> Search(FilterDto filterDto)
        {
            using (var context = new FSEP01Context())
            {
                var data = from rd in context.RoleDemands
                           join r in context.Roles on rd.RoleId equals r.Id
                           join d in context.Demands on rd.DemandId equals d.Id
                           where rd.IsActive == true && (
                           rd.Optime.ToString().Contains(filterDto.Filter) ||
                           r.RoleName.Contains(filterDto.Filter) ||
                           d.DemandName.Contains(filterDto.Filter))
                           select new RoleDemandDto
                           {
                               Id = rd.Id,
                               Optime = rd.Optime,
                               IsActive = rd.IsActive,
                               RoleId = r.Id,
                               RoleName = r.RoleName,
                               DemandId = d.Id,
                               DemandName = d.DemandName,
                           };

                return data.ToList();
            }
        }
    }
}
