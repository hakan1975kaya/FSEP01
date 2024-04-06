using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.RoleDemand;
using Entities.Concrete.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleDemandService
    {
        public Task<IResult> Add(RoleDemand roleDemand);
        public Task<IResult> Update(RoleDemand roleDemand);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RoleDemand>> GetById(Guid id);
        public Task<IDataResult<List<RoleDemand>>> GetAll ();
        public Task<IDataResult<List<RoleDemandDto>>> Search(FilterDto filterDto);
    }
}
