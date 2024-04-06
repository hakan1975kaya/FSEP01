using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.RoleValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Entities.WEB;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        [SecurityAspect("Role.Add", Priority = 2)]
        [ValidationAspect(typeof(RoleValidator),Priority =3)]
        [CacheRemoveAspect("IRoleService.Get", Priority = 4)]
        public async Task<IResult> Add(Role role)
        {
            await _roleDal.Add(role);
            return new SuccessResult(RoleMessages.Added);
        }

        [SecurityAspect("Role.Delete", Priority =2)]
        [CacheRemoveAspect("IRoleService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var roleDataResult = await GetById(id);
            if (roleDataResult != null)
            {
                if (roleDataResult.Success)
                {
                    var role = roleDataResult.Data;
                    role.IsActive = false;
                    await _roleDal.Update(role);
                    return new SuccessResult(RoleMessages.Deleted);
                }
            }
            return new ErrorResult(RoleMessages.OperationFailed);
        }

        [SecurityAspect("Role.GetAll", Priority = 2)]
        [CacheAspect(Priority =3)]
        public async Task<IDataResult<List<Role>>> GetAll()
        {
            return new SuccessDataResult<List<Role>>(await _roleDal.GetList(x => x.IsActive == true));
        }

        [SecurityAspect("Role.GetById", Priority = 2)]
        public async Task<IDataResult<Role>> GetById(Guid id)
        {
            return new SuccessDataResult<Role>(await _roleDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Role.Search", Priority = 2)]
        public async Task<IDataResult<List<Role>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Role>>(await _roleDal.GetList(x => x.IsActive == true && (x.RoleName.Contains( filterDto.Filter) || x.Optime.ToString().Contains( filterDto.Filter))));
        }

        [SecurityAspect("Role.Update", Priority = 2)]
        [ValidationAspect(typeof(RoleValidator), Priority = 3)]
        [CacheRemoveAspect("IRoleService.Get", Priority = 4)]
        public async Task<IResult> Update(Role role)
        {
            await _roleDal.Update(role);
            return new SuccessResult(RoleMessages.Updated);
        }
    }
}
