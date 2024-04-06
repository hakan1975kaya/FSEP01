using Business.Abstract;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.AuthValidators;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.General;
using Entities.Concrete.Dtos.General.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class AuthManager : IAuthService
    {
        private IUserDal _userDal;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserDal userDal, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(LoginDtoValidator) ,Priority = 2)]
        public async Task<IDataResult<AccessToken>> Login(LoginDto loginDto)
        {
            var registrationNumber = loginDto.RegistrationNumber;
            var password = loginDto.Password;
            var user = await _userDal.Get(x => x.RegistrationNumber == registrationNumber && x.IsActive == true);
            if (user != null)
            {
                var isVerified =  HashingHelper.VeryfyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                if (isVerified)
                {
                    var demands = await _userDal.GetDemandsByUserId(user.Id);
                    var menus = await _userDal.GetMenusByUserId(user.Id);
                    var accessToken =  _tokenHelper.CreateToken(user, demands, menus);

                    return new SuccessDataResult<AccessToken>(accessToken, AuthMessages.LoginSuccess);
                }
            }
            return new ErrorDataResult<AccessToken>(null, AuthMessages.LoginFailed);
        }

        [ValidationAspect(typeof(RegisterDtoValidator), Priority = 2)]
        public async Task<IDataResult<AccessToken>> Register(RegisterDto registerDto)
        {
            var registrationNumber = registerDto.RegistrationNumber;
            var password = registerDto.Password;
            var firstName = registerDto.FirstName;
            var lastName = registerDto.LastName;

            var user = await _userDal.Get(x => x.RegistrationNumber == registrationNumber && x.IsActive == true);
            if (user == null)
            {
                byte[] passwordHash;
                byte[] passwordSalt;

                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user = new User
                {
                    Id = Guid.NewGuid(),
                    RegistrationNumber = registrationNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Optime = DateTime.Now,
                    IsActive = true
                };

                await _userDal.Add(user);

                var demands = await _userDal.GetDemandsByUserId(user.Id);
                var menus=await _userDal.GetMenusByUserId(user.Id);
                var accessToken =  _tokenHelper.CreateToken(user, demands, menus);

                return new SuccessDataResult<AccessToken>(accessToken,AuthMessages.RegisterSuccess);
            }

            return new ErrorDataResult<AccessToken>(null, AuthMessages.RegisterFailed);

        }
    }
}
