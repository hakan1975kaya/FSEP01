using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.General.DemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.ProcessCoils;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ProcessCoilManager : IProcessCoilService
    {
        private IProcessCoilDal _processCoilDal;
        public ProcessCoilManager(IProcessCoilDal processCoilDal)
        {
            _processCoilDal = processCoilDal;
        }

        [SecurityAspect("ProcessCoil.Add", Priority = 2)]
        [ValidationAspect(typeof(ProcessCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IProcessCoilService.Get", Priority = 4)]
        public async Task<IResult> Add(ProcessCoil processCoil)
        {
            await _processCoilDal.Add(processCoil);
            return new SuccessResult(ProcessCoilMessages.Added);
        }

        [SecurityAspect("ProcessCoil.Delete", Priority = 2)]
        [CacheRemoveAspect("IProcessCoilService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var processCoilDataResult = await GetById(id);
            if (processCoilDataResult != null)
            {
                if (processCoilDataResult.Success)
                {
                    var processCoil = processCoilDataResult.Data;
                    processCoil.IsActive = false;
                    await _processCoilDal.Update(processCoil);
                    return new SuccessResult(ProcessCoilMessages.Deleted);
                }
            }
            return new ErrorResult(ProcessCoilMessages.OperationFailed);
        }

        [SecurityAspect("ProcessCoil.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ProcessCoil>>> GetAll()
        {
            var processCoils = await _processCoilDal.GetList(x => x.IsActive == true);
            processCoils = processCoils.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<ProcessCoil>>(processCoils);
        }

        [SecurityAspect("ProcessCoil.GetById", Priority = 2)]
        public async Task<IDataResult<ProcessCoil>> GetById(Guid id)
        {
            return new SuccessDataResult<ProcessCoil>(await _processCoilDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ProcessCoil.Search", Priority = 2)]
        public async Task<IDataResult<List<ProcessCoil>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ProcessCoil>>(await _processCoilDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ProcessCoil.Update", Priority = 2)]
        [ValidationAspect(typeof(ProcessCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IProcessCoilService.Get", Priority = 4)]
        public async Task<IResult> Update(ProcessCoil processCoil)
        {
            await _processCoilDal.Update(processCoil);
            return new SuccessResult(ProcessCoilMessages.Updated);
        }
    }
}
