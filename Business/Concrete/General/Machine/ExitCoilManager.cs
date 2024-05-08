using Business.Abstract.General.Machine;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.Machine;
using Business.Validators.FluentValidators.General.Machine.ExitCoilValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ExitCoilManager : IExitCoilService
    {
        private IExitCoilDal _exitCoilDal;
        public ExitCoilManager(IExitCoilDal exitCoilDal)
        {
            _exitCoilDal = exitCoilDal;
        }

        [SecurityAspect("ExitCoil.Add", Priority = 2)]
        [ValidationAspect(typeof(ExitCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IExitCoilService.Get", Priority = 4)]
        public async Task<IResult> Add(ExitCoil exitCoil)
        {
            await _exitCoilDal.Add(exitCoil);
            return new SuccessResult(ExitCoilMessages.Added);
        }

        [SecurityAspect("ExitCoil.Delete", Priority = 2)]
        [CacheRemoveAspect("IExitCoilService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var ExitCoilDataResult = await GetById(id);
            if (ExitCoilDataResult != null)
            {
                if (ExitCoilDataResult.Success)
                {
                    var ExitCoil = ExitCoilDataResult.Data;
                    ExitCoil.IsActive = false;
                    await _exitCoilDal.Update(ExitCoil);
                    return new SuccessResult(ExitCoilMessages.Deleted);
                }
            }
            return new ErrorResult(ExitCoilMessages.OperationFailed);
        }

        [SecurityAspect("ExitCoil.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ExitCoil>>> GetAll()
        {
            var ExitCoils = await _exitCoilDal.GetList(x => x.IsActive == true);
            ExitCoils = ExitCoils.OrderBy(x => x.OperatorName).ToList();
            return new SuccessDataResult<List<ExitCoil>>(ExitCoils);
        }

        [SecurityAspect("ExitCoil.GetById", Priority = 2)]
        public async Task<IDataResult<ExitCoil>> GetById(Guid id)
        {
            return new SuccessDataResult<ExitCoil>(await _exitCoilDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ExitCoil.Search", Priority = 2)]
        public async Task<IDataResult<List<ExitCoil>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ExitCoil>>(await _exitCoilDal.GetList(x => x.IsActive == true && (x.Optime.ToString().Contains(filterDto.Filter) || x.OperatorName.Contains(filterDto.Filter))));
        }

        [SecurityAspect("ExitCoil.Update", Priority = 2)]
        [ValidationAspect(typeof(ExitCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IExitCoilService.Get", Priority = 4)]
        public async Task<IResult> Update(ExitCoil exitCoil)
        {
            await _exitCoilDal.Update(exitCoil);
            return new SuccessResult(ExitCoilMessages.Updated);
        }
    }
}
