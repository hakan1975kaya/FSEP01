using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.UserRoleValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Dtos.UserRole;
using Entities.Concrete.Entities;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class UserRoleManager : IUserRoleService
    {
        private IUserRoleDal _userRoleDal;
        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        [SecurityAspect("UserRole.Add", Priority = 2)]
        [ValidationAspect(typeof(UserRoleValidator), Priority = 3)]
        [CacheRemoveAspect("IUserRoleService.Get", Priority = 4)]
        public async Task<IResult> Add(UserRole userRole)
        {
            await _userRoleDal.Add(userRole);
            return new SuccessResult(UserRoleMessages.Added);
        }

        [SecurityAspect("UserRole.Delete", Priority = 2)]
        [CacheRemoveAspect("IUserRoleService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var userRoleDataResult = await GetById(id);
            if (userRoleDataResult != null)
            {
                if (userRoleDataResult.Success)
                {
                    var userRole = userRoleDataResult.Data;
                    userRole.IsActive = false;
                    await _userRoleDal.Update(userRole);
                    return new SuccessResult(UserRoleMessages.Deleted);
                }
            }
            return new ErrorResult(UserRoleMessages.OperationFailed);
        }

        [SecurityAspect("UserRole.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<UserRole>>> GetAll()
        {
            return new SuccessDataResult<List<UserRole>>(await _userRoleDal.GetList(x => x.IsActive == true));
        }

        [SecurityAspect("UserRole.GetById", Priority = 2)]
        public async Task<IDataResult<UserRole>> GetById(Guid id)
        {
            return new SuccessDataResult<UserRole>(await _userRoleDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("UserRole.Search", Priority = 2)]
        public async Task<IDataResult<List<UserRoleDto>>> Search(FilterDto filterDto)
        {
          return new SuccessDataResult<List<UserRoleDto>>(await _userRoleDal.Search(filterDto));
        }

        [SecurityAspect("UserRole.Update", Priority = 2)]
        [ValidationAspect(typeof(UserRoleValidator), Priority = 3)]
        [CacheRemoveAspect("IUserRoleService.Get", Priority = 4)]
        public async Task<IResult> Update(UserRole userRole)
        {
            await _userRoleDal.Update(userRole);
            return new SuccessResult(UserRoleMessages.Updated);
        }
    }
}
