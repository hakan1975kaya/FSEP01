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
    public class LevelThreeTelegramManager : ILevelThreeTelegramService
    {
        private ILevelThreeTelegramDal _levelThreeTelegramDal;
        public LevelThreeTelegramManager(ILevelThreeTelegramDal levelThreeTelegramDal)
        {
            _levelThreeTelegramDal = levelThreeTelegramDal;
        }

        [SecurityAspect("LevelThreeTelegram.Add", Priority = 2)]
        [ValidationAspect(typeof(LevelThreeTelegramValidator), Priority = 3)]
        [CacheRemoveAspect("ILevelThreeTelegramService.Get", Priority = 4)]
        public async Task<IResult> Add(LevelThreeTelegram levelThreeTelegram)
        {
            await _levelThreeTelegramDal.Add(levelThreeTelegram);
            return new SuccessResult(LevelThreeTelegramMessages.Added);
        }

        [SecurityAspect("LevelThreeTelegram.Delete", Priority = 2)]
        [CacheRemoveAspect("ILevelThreeTelegramService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var levelThreeTelegramDataResult = await GetById(id);
            if (levelThreeTelegramDataResult != null)
            {
                if (levelThreeTelegramDataResult.Success)
                {
                    var levelThreeTelegram = levelThreeTelegramDataResult.Data;
                    levelThreeTelegram.IsActive = false;
                    await _levelThreeTelegramDal.Update(levelThreeTelegram);
                    return new SuccessResult(LevelThreeTelegramMessages.Deleted);
                }
            }
            return new ErrorResult(LevelThreeTelegramMessages.OperationFailed);
        }

        [SecurityAspect("LevelThreeTelegram.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<LevelThreeTelegram>>> GetAll()
        {
            var levelThreeTelegrams = await _levelThreeTelegramDal.GetList(x => x.IsActive == true);
            levelThreeTelegrams = levelThreeTelegrams.OrderBy(x => x.LineId).ToList();
            return new SuccessDataResult<List<LevelThreeTelegram>>(levelThreeTelegrams);
        }

        [SecurityAspect("LevelThreeTelegram.GetById", Priority = 2)]
        public async Task<IDataResult<LevelThreeTelegram>> GetById(Guid id)
        {
            return new SuccessDataResult<LevelThreeTelegram>(await _levelThreeTelegramDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("LevelThreeTelegram.Search", Priority = 2)]
        public async Task<IDataResult<List<LevelThreeTelegram>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<LevelThreeTelegram>>(await _levelThreeTelegramDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("LevelThreeTelegram.Update", Priority = 2)]
        [ValidationAspect(typeof(LevelThreeTelegramValidator), Priority = 3)]
        [CacheRemoveAspect("ILevelThreeTelegramService.Get", Priority = 4)]
        public async Task<IResult> Update(LevelThreeTelegram levelThreeTelegram)
        {
            await _levelThreeTelegramDal.Update(levelThreeTelegram);
            return new SuccessResult(LevelThreeTelegramMessages.Updated);
        }
    }
}
