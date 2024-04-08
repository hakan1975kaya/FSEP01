using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General.General
{
    public interface IRoleService
    {
        public Task<IResult> Add(Role role);
        public Task<IResult> Update(Role role);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Role>> GetById(Guid id);
        public Task<IDataResult<List<Role>>> GetAll();
        public Task<IDataResult<List<Role>>> Search(FilterDto filterDto);
    }
}
