using Business.Abstract.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.RoleMenuValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.RoleMenu;
using Entities.Concrete.Entities.General;


namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class RoleMenuManager : IRoleMenuService
    {
        private IRoleMenuDal _roleMenuDal;
        public RoleMenuManager(IRoleMenuDal roleMenuDal)
        {
            _roleMenuDal = roleMenuDal;
        }

        [SecurityAspect("RoleMenu.Add", Priority = 2)]
        [ValidationAspect(typeof(RoleMenuValidator), Priority = 3)]
        [CacheRemoveAspect("IRoleMenuService.Get", Priority = 4)]
        public async Task<IResult> Add(RoleMenu roleMenu)
        {
            await _roleMenuDal.Add(roleMenu);
            return new SuccessResult(RoleMenuMessages.Added);
        }

        [SecurityAspect("RoleMenu.Delete", Priority = 2)]
        [CacheRemoveAspect("IRoleMenuService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var roleMenuDataResult = await GetById(id);
            if (roleMenuDataResult != null)
            {
                if (roleMenuDataResult.Success)
                {
                    var roleMenu = roleMenuDataResult.Data;
                    roleMenu.IsActive = false;
                    await _roleMenuDal.Update(roleMenu);
                    return new SuccessResult(RoleMenuMessages.Deleted);
                }
            }
            return new ErrorResult(RoleMenuMessages.OperationFailed);
        }

        [SecurityAspect("RoleMenu.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RoleMenu>>> GetAll()
        {
            return new SuccessDataResult<List<RoleMenu>>(await _roleMenuDal.GetList(x => x.IsActive == true));
        }

        [SecurityAspect("RoleMenu.GetById", Priority = 2)]
        public async Task<IDataResult<RoleMenu>> GetById(Guid id)
        {
            return new SuccessDataResult<RoleMenu>(await _roleMenuDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RoleMenu.Search", Priority = 2)]
        public async Task<IDataResult<List<RoleMenuDto>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RoleMenuDto>>(await _roleMenuDal.Search(filterDto));
        }

        [SecurityAspect("RoleMenu.Update", Priority = 2)]
        [ValidationAspect(typeof(RoleMenuValidator), Priority = 3)]
        [CacheRemoveAspect("IRoleMenuService.Get", Priority = 4)]
        public async Task<IResult> Update(RoleMenu roleMenu)
        {
            await _roleMenuDal.Update(roleMenu);
            return new SuccessResult(RoleMenuMessages.Updated);
        }
    }
}
