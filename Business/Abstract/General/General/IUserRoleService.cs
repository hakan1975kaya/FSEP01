using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.UserRole;
using Entities.Concrete.Entities.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General.General
{
    public interface IUserRoleService
    {
        public Task<IResult> Add(UserRole userRole);
        public Task<IResult> Update(UserRole userRole);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<UserRole>> GetById(Guid id);
        public Task<IDataResult<List<UserRole>>> GetAll();
        public Task<IDataResult<List<UserRoleDto>>> Search(FilterDto filterDto);
    }
}
