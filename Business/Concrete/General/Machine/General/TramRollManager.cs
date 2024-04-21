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
    public class TramRollManager : ITramRollService
    {
        private ITramRollDal _tramRollDal;
        public TramRollManager(ITramRollDal tramRollDal)
        {
            _tramRollDal = tramRollDal;
        }

        [SecurityAspect("TramRoll.Add", Priority = 2)]
        [ValidationAspect(typeof(TramRollValidator), Priority = 3)]
        [CacheRemoveAspect("ITramRollService.Get", Priority = 4)]
        public async Task<IResult> Add(TramRoll tramRoll)
        {
            await _tramRollDal.Add(tramRoll);
            return new SuccessResult(TramRollMessages.Added);
        }

        [SecurityAspect("TramRoll.Delete", Priority = 2)]
        [CacheRemoveAspect("ITramRollService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var tramRollDataResult = await GetById(id);
            if (tramRollDataResult != null)
            {
                if (tramRollDataResult.Success)
                {
                    var tramRoll = tramRollDataResult.Data;
                    tramRoll.IsActive = false;
                    await _tramRollDal.Update(tramRoll);
                    return new SuccessResult(TramRollMessages.Deleted);
                }
            }
            return new ErrorResult(TramRollMessages.OperationFailed);
        }

        [SecurityAspect("TramRoll.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<TramRoll>>> GetAll()
        {
            var tramRolls = await _tramRollDal.GetList(x => x.IsActive == true);
            tramRolls = tramRolls.OrderBy(x => x.RollName).ToList();
            return new SuccessDataResult<List<TramRoll>>(tramRolls);
        }

        [SecurityAspect("TramRoll.GetById", Priority = 2)]
        public async Task<IDataResult<TramRoll>> GetById(Guid id)
        {
            return new SuccessDataResult<TramRoll>(await _tramRollDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("TramRoll.Search", Priority = 2)]
        public async Task<IDataResult<List<TramRoll>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<TramRoll>>(await _tramRollDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("TramRoll.Update", Priority = 2)]
        [ValidationAspect(typeof(TramRollValidator), Priority = 3)]
        [CacheRemoveAspect("ITramRollService.Get", Priority = 4)]
        public async Task<IResult> Update(TramRoll tramRoll)
        {
            await _tramRollDal.Update(tramRoll);
            return new SuccessResult(TramRollMessages.Updated);
        }
    }
}
