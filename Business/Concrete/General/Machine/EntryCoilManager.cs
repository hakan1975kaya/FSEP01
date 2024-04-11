using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.General.EntryCoilValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class EntryCoilManager : IEntryCoilService
    {
        private IEntryCoilDal _entryCoilDal;
        public EntryCoilManager(IEntryCoilDal entryCoilDal)
        {
            _entryCoilDal = entryCoilDal;
        }

        [SecurityAspect("EntryCoil.Add", Priority = 2)]
        [ValidationAspect(typeof(EntryCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IEntryCoilService.Get", Priority = 4)]
        public async Task<IResult> Add(EntryCoil entryCoil)
        {
            await _entryCoilDal.Add(entryCoil);
            return new SuccessResult(EntryCoilMessages.Added);
        }

        [SecurityAspect("EntryCoil.Delete", Priority = 2)]
        [CacheRemoveAspect("IEntryCoilService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var entryCoilDataResult = await GetById(id);
            if (entryCoilDataResult != null)
            {
                if (entryCoilDataResult.Success)
                {
                    var entryCoil = entryCoilDataResult.Data;
                    entryCoil.IsActive = false;
                    await _entryCoilDal.Update(entryCoil);
                    return new SuccessResult(EntryCoilMessages.Deleted);
                }
            }
            return new ErrorResult(EntryCoilMessages.OperationFailed);
        }

        [SecurityAspect("EntryCoil.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<EntryCoil>>> GetAll()
        {
            var entryCoils = await _entryCoilDal.GetList(x => x.IsActive == true);
            entryCoils = entryCoils.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<EntryCoil>>(entryCoils);
        }

        [SecurityAspect("EntryCoil.GetById", Priority = 2)]
        public async Task<IDataResult<EntryCoil>> GetById(Guid id)
        {
            return new SuccessDataResult<EntryCoil>(await _entryCoilDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("EntryCoil.Search", Priority = 2)]
        public async Task<IDataResult<List<EntryCoil>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<EntryCoil>>(await _entryCoilDal.GetList(x => x.IsActive == true && (x.Optime.ToString().Contains(filterDto.Filter) || x.LocalId.Contains(filterDto.Filter))));
        }

        [SecurityAspect("EntryCoil.Update", Priority = 2)]
        [ValidationAspect(typeof(EntryCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IEntryCoilService.Get", Priority = 4)]
        public async Task<IResult> Update(EntryCoil entryCoil)
        {
            await _entryCoilDal.Update(entryCoil);
            return new SuccessResult(EntryCoilMessages.Updated);
        }
    }
}
