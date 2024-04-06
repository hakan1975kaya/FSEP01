using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.RoleDemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Dtos.General.RoleDemand;
using Entities.Concrete.Entities.General;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class RoleDemandManager : IRoleDemandService
    {
        private IRoleDemandDal _roleDemandDal;
        public RoleDemandManager(IRoleDemandDal roleDemandDal)
        {
            _roleDemandDal = roleDemandDal;
        }

        [SecurityAspect("RoleDemand.Add", Priority = 2)]
        [ValidationAspect(typeof(RoleDemandValidator), Priority = 3)]
        [CacheRemoveAspect("IRoleDemandService.Get", Priority = 4)]
        public async Task<IResult> Add(RoleDemand roleDemand)
        {
            await _roleDemandDal.Add(roleDemand);
            return new SuccessResult(RoleDemandMessages.Added);
        }

        [SecurityAspect("RoleDemand.Delete", Priority = 2)]
        [CacheRemoveAspect("IRoleDemandService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var roleDemandDataResult = await GetById(id);
            if (roleDemandDataResult != null)
            {
                if (roleDemandDataResult.Success)
                {
                    var roleDemand = roleDemandDataResult.Data;
                    roleDemand.IsActive = false;
                    await _roleDemandDal.Update(roleDemand);
                    return new SuccessResult(RoleDemandMessages.Deleted);
                }
            }
            return new ErrorResult(RoleDemandMessages.OperationFailed);
        }

        [SecurityAspect("RoleDemand.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RoleDemand>>> GetAll()
        {
            return new SuccessDataResult<List<RoleDemand>>(await _roleDemandDal.GetList(x => x.IsActive == true));
        }

        [SecurityAspect("RoleDemand.GetById", Priority = 2)]
        public async Task<IDataResult<RoleDemand>> GetById(Guid id)
        {
            return new SuccessDataResult<RoleDemand>(await _roleDemandDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RoleDemand.Search", Priority = 2)]
        public async Task<IDataResult<List<RoleDemandDto>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RoleDemandDto>> (await _roleDemandDal.Search(filterDto));
        }

        [SecurityAspect("RoleDemand.Update", Priority = 2)]
        [ValidationAspect(typeof(RoleDemandValidator), Priority = 3)]
        [CacheRemoveAspect("IRoleDemandService.Get", Priority = 4)]
        public async Task<IResult> Update(RoleDemand roleDemand)
        {
            await _roleDemandDal.Update(roleDemand);
            return new SuccessResult(RoleDemandMessages.Updated);
        }
    }
}
