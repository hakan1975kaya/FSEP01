using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.General.UserValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.User;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [SecurityAspect("User.Add", Priority = 2)]
        [ValidationAspect(typeof(UserDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserService.Get", Priority = 4)]
        public async Task<IResult> Add(UserDto userDto)
        {
            var registrationNumber = userDto.RegistrationNumber;
            var password = userDto.Password;
            var firstName = userDto.FirstName;
            var lastName = userDto.LastName;

            if (!string.IsNullOrEmpty(password))
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
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
            }
            else
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    RegistrationNumber = registrationNumber,
                    FirstName = firstName,
                    LastName = lastName,
                    PasswordSalt = null,
                    PasswordHash = null,
                    Optime = DateTime.Now,
                    IsActive = true
                };
                await _userDal.Add(user);
            }

            return new SuccessResult(UserMessages.Added);
        }

        [SecurityAspect("User.PasswordChange", Priority = 2)]
        [ValidationAspect(typeof(PasswordChangeDtoValidator), Priority = 3)]
        public async Task<IResult> PasswordChange(PasswordChangeDto passwordChangeDto)
        {
            var registrationNumber = passwordChangeDto.RegistrationNumber;
            var password = passwordChangeDto.Password;

            var user = await _userDal.Get(x => x.RegistrationNumber == registrationNumber && x.IsActive == true);
            if (user != null)
            {
                byte[] passwordHash;
                byte[] passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.RegistrationNumber = registrationNumber;
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.Optime = DateTime.Now;
                user.IsActive = true;

                await _userDal.Update(user);
            }
            return new SuccessResult(UserMessages.PasswordChanged);
        }

        [SecurityAspect("User.Delete", Priority = 2)]
        [CacheRemoveAspect("IUserService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var userDataResult = await GetById(id);
            if (userDataResult != null)
            {
                if (userDataResult.Success)
                {
                    var user = userDataResult.Data;
                    user.IsActive = false;
                    await _userDal.Update(user);
                    return new SuccessResult(UserMessages.Deleted);
                }
            }
            return new ErrorResult(UserMessages.OperationFailed);
        }

        [SecurityAspect("User.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<User>>> GetAll()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetList(x => x.IsActive == true));
        }

        [SecurityAspect("User.GetById", Priority = 2)]
        public async Task<IDataResult<User>> GetById(Guid id)
        {
            return new SuccessDataResult<User>(await _userDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("User.Search", Priority = 2)]
        public async Task<IDataResult<List<User>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetList(x => x.IsActive == true && (x.RegistrationNumber.ToString().Contains(filterDto.Filter) || x.FirstName.Contains(filterDto.Filter) || x.LastName.Contains(filterDto.Filter) || x.Optime.ToString().Contains(filterDto.Filter))));
        }

        [SecurityAspect("User.Update", Priority = 2)]
        [ValidationAspect(typeof(UserDtoValidator), Priority = 3)]
        [CacheRemoveAspect("IUserService.Get", Priority = 4)]
        public async Task<IResult> Update(UserDto userDto)
        {
            var registrationNumber = userDto.RegistrationNumber;
            var password = userDto.Password;
            var firstName = userDto.FirstName;
            var lastName = userDto.LastName;

            var user = await _userDal.Get(x => x.RegistrationNumber == registrationNumber && x.IsActive == true);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(password))
                {
                    byte[] passwordHash;
                    byte[] passwordSalt;
                    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                    user.RegistrationNumber = registrationNumber;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.PasswordSalt = passwordSalt;
                    user.PasswordHash = passwordHash;
                    user.Optime = DateTime.Now;
                    user.IsActive = true;

                    await _userDal.Update(user);
                }
                else
                {
                    user.RegistrationNumber = registrationNumber;
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.Optime = DateTime.Now;
                    user.IsActive = true;

                    await _userDal.Update(user);
                }
            }
            return new SuccessResult(UserMessages.Updated);
        }



    }
}
