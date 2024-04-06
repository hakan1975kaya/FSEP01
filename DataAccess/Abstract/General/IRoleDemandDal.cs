using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.RoleDemand;
using Entities.Concrete.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General
{
    public interface IRoleDemandDal : IEntityRepositoryBase<RoleDemand>
    {
        public Task<List<RoleDemandDto>> Search(FilterDto filterDto);
    }
}
