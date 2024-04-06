using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.User;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<IResult> Add(UserDto userDto);
        public Task<IResult> Update(UserDto userDto);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<User>> GetById(Guid id);
        public Task<IDataResult<List<User>>> GetAll();
        public Task<IDataResult<List<User>>> Search(FilterDto filterDto);
        public Task<IResult> PasswordChange(PasswordChangeDto passwordChangeDto);
    }
}
