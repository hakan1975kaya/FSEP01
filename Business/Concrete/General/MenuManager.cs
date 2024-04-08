using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General;
using Business.Validators.FluentValidators.General.MenuValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;

namespace Business.Concrete.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        [SecurityAspect("Menu.Add", Priority = 2)]
        [ValidationAspect(typeof(MenuValidator), Priority = 3)]
        [CacheRemoveAspect("IMenuService.Get", Priority = 4)]
        public async Task<IResult> Add(Menu menu)
        {
            await _menuDal.Add(menu);
            return new SuccessResult(MenuMessages.Added);
        }

        [SecurityAspect("Menu.Delete", Priority = 2)]
        [CacheRemoveAspect("IMenuService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var menuDataResult = await GetById(id);
            if (menuDataResult != null)
            {
                if (menuDataResult.Success)
                {
                    var menu = menuDataResult.Data;
                    menu.IsActive = false;
                    await _menuDal.Update(menu);
                    return new SuccessResult(MenuMessages.Deleted);
                }
            }
            return new ErrorResult(MenuMessages.OperationFailed);
        }

        [SecurityAspect("Menu.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Menu>>> GetAll()
        {
            var menus = await _menuDal.GetList(x => x.IsActive == true);
            menus = menus.OrderBy(x => x.MenuOrder).ToList();
            return new SuccessDataResult<List<Menu>>(menus);
        }

        [SecurityAspect("Menu.GetById", Priority = 2)]
        public async Task<IDataResult<Menu>> GetById(Guid id)
        {
            return new SuccessDataResult<Menu>(await _menuDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Menu.Search", Priority = 2)]
        public async Task<IDataResult<List<Menu>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Menu>>(await _menuDal.GetList(x => x.IsActive == true && (x.Path.Contains(filterDto.Filter) || filterDto.Filter.Contains(x.Description) || x.MenuName.Contains(filterDto.Filter) || x.Optime.ToString().Contains(filterDto.Filter) || x.MenuOrder.ToString().Contains(filterDto.Filter))));
        }

        [SecurityAspect("Menu.Update", Priority = 2)]
        [ValidationAspect(typeof(MenuValidator), Priority = 3)]
        [CacheRemoveAspect("IMenuService.Get", Priority = 4)]
        public async Task<IResult> Update(Menu menu)
        {
            await _menuDal.Update(menu);
            return new SuccessResult(MenuMessages.Updated);
        }
    }
}
