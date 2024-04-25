using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.Machine.General;
using Business.Validators.FluentValidators.General.General.DemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class DensityManager : IDensityService
    {
        private IDensityDal _densityDal;
        public DensityManager(IDensityDal densityDal)
        {
            _densityDal = densityDal;
        }

        [SecurityAspect("Density.Add", Priority = 2)]
        [ValidationAspect(typeof(DensityValidator), Priority = 3)]
        [CacheRemoveAspect("IDensityService.Get", Priority = 4)]
        public async Task<IResult> Add(Density density)
        {
            await _densityDal.Add(density);
            return new SuccessResult(DensityMessages.Added);
        }

        [SecurityAspect("Density.Delete", Priority = 2)]
        [CacheRemoveAspect("IDensityService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var densityDataResult = await GetById(id);
            if (densityDataResult != null)
            {
                if (densityDataResult.Success)
                {
                    var density = densityDataResult.Data;
                    density.IsActive = false;
                    await _densityDal.Update(density);
                    return new SuccessResult(DensityMessages.Deleted);
                }
            }
            return new ErrorResult(DensityMessages.OperationFailed);
        }

        [SecurityAspect("Density.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Density>>> GetAll()
        {
            var densitys = await _densityDal.GetList(x => x.IsActive == true);
            densitys = densitys.OrderBy(x => x.Value).ToList();
            return new SuccessDataResult<List<Density>>(densitys);
        }

        [SecurityAspect("Density.GetById", Priority = 2)]
        public async Task<IDataResult<Density>> GetById(Guid id)
        {
            return new SuccessDataResult<Density>(await _densityDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Density.Search", Priority = 2)]
        public async Task<IDataResult<List<Density>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Density>>(await _densityDal.GetList(x =>
            x.IsActive == true &&
            (x.Optime.ToString().Contains(filterDto.Filter) ||
            x.Alloy.Contains(filterDto.Filter) ||
            x.Value.ToString().Contains(filterDto.Filter))));
        }

        [SecurityAspect("Density.Update", Priority = 2)]
        [ValidationAspect(typeof(DensityValidator), Priority = 3)]
        [CacheRemoveAspect("IDensityService.Get", Priority = 4)]
        public async Task<IResult> Update(Density density)
        {
            await _densityDal.Update(density);
            return new SuccessResult(DensityMessages.Updated);
        }
    }
}
