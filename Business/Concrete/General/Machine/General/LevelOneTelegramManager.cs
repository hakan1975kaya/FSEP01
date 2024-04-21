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
    public class LevelOneTelegramManager : ILevelOneTelegramService
    {
        private ILevelOneTelegramDal _levelOneTelegramDal;
        public LevelOneTelegramManager(ILevelOneTelegramDal levelOneTelegramDal)
        {
            _levelOneTelegramDal = levelOneTelegramDal;
        }

        [SecurityAspect("LevelOneTelegram.Add", Priority = 2)]
        [ValidationAspect(typeof(LevelOneTelegramValidator), Priority = 3)]
        [CacheRemoveAspect("ILevelOneTelegramService.Get", Priority = 4)]
        public async Task<IResult> Add(LevelOneTelegram levelOneTelegram)
        {
            await _levelOneTelegramDal.Add(levelOneTelegram);
            return new SuccessResult(LevelOneTelegramMessages.Added);
        }

        [SecurityAspect("LevelOneTelegram.Delete", Priority = 2)]
        [CacheRemoveAspect("ILevelOneTelegramService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var levelOneTelegramDataResult = await GetById(id);
            if (levelOneTelegramDataResult != null)
            {
                if (levelOneTelegramDataResult.Success)
                {
                    var levelOneTelegram = levelOneTelegramDataResult.Data;
                    levelOneTelegram.IsActive = false;
                    await _levelOneTelegramDal.Update(levelOneTelegram);
                    return new SuccessResult(LevelOneTelegramMessages.Deleted);
                }
            }
            return new ErrorResult(LevelOneTelegramMessages.OperationFailed);
        }

        [SecurityAspect("LevelOneTelegram.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<LevelOneTelegram>>> GetAll()
        {
            var levelOneTelegrams = await _levelOneTelegramDal.GetList(x => x.IsActive == true);
            levelOneTelegrams = levelOneTelegrams.OrderBy(x => x.LineId).ToList();
            return new SuccessDataResult<List<LevelOneTelegram>>(levelOneTelegrams);
        }

        [SecurityAspect("LevelOneTelegram.GetById", Priority = 2)]
        public async Task<IDataResult<LevelOneTelegram>> GetById(Guid id)
        {
            return new SuccessDataResult<LevelOneTelegram>(await _levelOneTelegramDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("LevelOneTelegram.Search", Priority = 2)]
        public async Task<IDataResult<List<LevelOneTelegram>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<LevelOneTelegram>>(await _levelOneTelegramDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("LevelOneTelegram.Update", Priority = 2)]
        [ValidationAspect(typeof(LevelOneTelegramValidator), Priority = 3)]
        [CacheRemoveAspect("ILevelOneTelegramService.Get", Priority = 4)]
        public async Task<IResult> Update(LevelOneTelegram levelOneTelegram)
        {
            await _levelOneTelegramDal.Update(levelOneTelegram);
            return new SuccessResult(LevelOneTelegramMessages.Updated);
        }
    }
}
