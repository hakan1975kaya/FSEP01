using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security;
using Entities.Concrete.Dtos.General.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General.General
{
    public interface IAuthService
    {
        public Task<IDataResult<AccessToken>> Register(RegisterDto registerDto);
        public Task<IDataResult<AccessToken>> Login(LoginDto loginDto);
    }
}
