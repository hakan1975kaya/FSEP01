using Business.Abstract.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General;
using Business.Validators.FluentValidators.General.DemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using System.Linq;

namespace Business.Concrete.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class DemandManager : IDemandService
    {
        private IDemandDal _demandDal;
        public DemandManager(IDemandDal demandDal)
        {
            _demandDal = demandDal;
        }

        [SecurityAspect("Demand.Add", Priority = 2)]
        [ValidationAspect(typeof(DemandValidator), Priority = 3)]
        [CacheRemoveAspect("IDemandService.Get", Priority = 4)]
        public async Task<IResult> Add(Demand demand)
        {
            await _demandDal.Add(demand);
            return new SuccessResult(DemandMessages.Added);
        }

        [SecurityAspect("Demand.Delete", Priority = 2)]
        [CacheRemoveAspect("IDemandService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var demandDataResult = await GetById(id);
            if (demandDataResult != null)
            {
                if (demandDataResult.Success)
                {
                    var demand = demandDataResult.Data;
                    demand.IsActive = false;
                    await _demandDal.Update(demand);
                    return new SuccessResult(DemandMessages.Deleted);
                }
            }
            return new ErrorResult(DemandMessages.OperationFailed);
        }

        [SecurityAspect("Demand.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Demand>>> GetAll()
        {
            var demands = await _demandDal.GetList(x => x.IsActive == true);
            demands = demands.OrderBy(x => x.DemandName).ToList();
            return new SuccessDataResult<List<Demand>>(demands);
        }

        [SecurityAspect("Demand.GetById", Priority = 2)]
        public async Task<IDataResult<Demand>> GetById(Guid id)
        {
            return new SuccessDataResult<Demand>(await _demandDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Demand.Search", Priority = 2)]
        public async Task<IDataResult<List<Demand>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Demand>>(await _demandDal.GetList(x => x.IsActive == true && (x.Optime.ToString().Contains(filterDto.Filter) || x.DemandName.Contains(filterDto.Filter))));
        }

        [SecurityAspect("Demand.Update", Priority = 2)]
        [ValidationAspect(typeof(DemandValidator), Priority = 3)]
        [CacheRemoveAspect("IDemandService.Get", Priority = 4)]
        public async Task<IResult> Update(Demand demand)
        {
            await _demandDal.Update(demand);
            return new SuccessResult(DemandMessages.Updated);
        }
    }
}
