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
using System.Reflection;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class DefinationManager : IDefinationService
    {
        private IDefinationDal _definationDal;
        public DefinationManager(IDefinationDal definationDal)
        {
            _definationDal = definationDal;
        }

        [SecurityAspect("Defination.Add", Priority = 2)]
        [ValidationAspect(typeof(DefinationValidator), Priority = 3)]
        [CacheRemoveAspect("IDefinationService.Get", Priority = 4)]
        public async Task<IResult> Add(Defination defination)
        {
            await _definationDal.Add(defination);
            return new SuccessResult(DefinationMessages.Added);
        }

        [SecurityAspect("Defination.Delete", Priority = 2)]
        [CacheRemoveAspect("IDefinationService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var definationDataResult = await GetById(id);
            if (definationDataResult != null)
            {
                if (definationDataResult.Success)
                {
                    var defination = definationDataResult.Data;
                    defination.IsActive = false;
                    await _definationDal.Update(defination);
                    return new SuccessResult(DefinationMessages.Deleted);
                }
            }
            return new ErrorResult(DefinationMessages.OperationFailed);
        }

        [SecurityAspect("Defination.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Defination>>> GetAll()
        {
            var definations = await _definationDal.GetList(x => x.IsActive == true);
            definations = definations.OrderBy(x => x.Sender).ToList();
            return new SuccessDataResult<List<Defination>>(definations);
        }

        [SecurityAspect("Defination.GetById", Priority = 2)]
        public async Task<IDataResult<Defination>> GetById(Guid id)
        {
            return new SuccessDataResult<Defination>(await _definationDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Defination.Search", Priority = 2)]
        public async Task<IDataResult<List<Defination>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Defination>>(await _definationDal.GetList(x =>
            x.IsActive == true &&
            (x.Optime.ToString().Contains(filterDto.Filter) ||
            x.MessageId.ToString().Contains(filterDto.Filter) ||
            x.TelegramType.Contains(filterDto.Filter) ||
            x.TelegramLength.Contains(filterDto.Filter) ||
            x.Sender.Contains(filterDto.Filter) ||
            x.Reciever.Contains(filterDto.Filter))));
        }

        [SecurityAspect("Defination.Update", Priority = 2)]
        [ValidationAspect(typeof(DefinationValidator), Priority = 3)]
        [CacheRemoveAspect("IDefinationService.Get", Priority = 4)]
        public async Task<IResult> Update(Defination defination)
        {
            await _definationDal.Update(defination);
            return new SuccessResult(DefinationMessages.Updated);
        }
    }
}
