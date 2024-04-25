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
    public class LubracationRollManager : ILubracationRollService
    {
        private ILubracationRollDal _lubracationRollDal;
        public LubracationRollManager(ILubracationRollDal lubracationRollDal)
        {
            _lubracationRollDal = lubracationRollDal;
        }

        [SecurityAspect("LubracationRoll.Add", Priority = 2)]
        [ValidationAspect(typeof(LubracationRollValidator), Priority = 3)]
        [CacheRemoveAspect("ILubracationRollService.Get", Priority = 4)]
        public async Task<IResult> Add(LubracationRoll lubracationRoll)
        {
            await _lubracationRollDal.Add(lubracationRoll);
            return new SuccessResult(LubracationRollMessages.Added);
        }

        [SecurityAspect("LubracationRoll.Delete", Priority = 2)]
        [CacheRemoveAspect("ILubracationRollService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var lubracationRollDataResult = await GetById(id);
            if (lubracationRollDataResult != null)
            {
                if (lubracationRollDataResult.Success)
                {
                    var lubracationRoll = lubracationRollDataResult.Data;
                    lubracationRoll.IsActive = false;
                    await _lubracationRollDal.Update(lubracationRoll);
                    return new SuccessResult(LubracationRollMessages.Deleted);
                }
            }
            return new ErrorResult(LubracationRollMessages.OperationFailed);
        }

        [SecurityAspect("LubracationRoll.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<LubracationRoll>>> GetAll()
        {
            var lubracationRolls = await _lubracationRollDal.GetList(x => x.IsActive == true);
            lubracationRolls = lubracationRolls.OrderBy(x => x.RollName).ToList();
            return new SuccessDataResult<List<LubracationRoll>>(lubracationRolls);
        }

        [SecurityAspect("LubracationRoll.GetById", Priority = 2)]
        public async Task<IDataResult<LubracationRoll>> GetById(Guid id)
        {
            return new SuccessDataResult<LubracationRoll>(await _lubracationRollDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("LubracationRoll.Search", Priority = 2)]
        public async Task<IDataResult<List<LubracationRoll>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<LubracationRoll>>(await _lubracationRollDal.GetList(x =>
          x.IsActive == true &&
            (x.Optime.ToString().Contains(filterDto.Filter) ||
            x.RollNumber.Contains(filterDto.Filter) ||
            x.RollDiameter.ToString().Contains(filterDto.Filter) ||
            x.GroupName.Contains(filterDto.Filter) ||
            x.RollName.Contains(filterDto.Filter))));
        }

        [SecurityAspect("LubracationRoll.Update", Priority = 2)]
        [ValidationAspect(typeof(LubracationRollValidator), Priority = 3)]
        [CacheRemoveAspect("ILubracationRollService.Get", Priority = 4)]
        public async Task<IResult> Update(LubracationRoll lubracationRoll)
        {
            await _lubracationRollDal.Update(lubracationRoll);
            return new SuccessResult(LubracationRollMessages.Updated);
        }
    }
}
