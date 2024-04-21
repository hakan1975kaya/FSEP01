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
using DataAccess.Abstract.General.Machine.OutputCoils;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class OutputCoilManager : IOutputCoilService
    {
        private IOutputCoilDal _outputCoilDal;
        public OutputCoilManager(IOutputCoilDal outputCoilDal)
        {
            _outputCoilDal = outputCoilDal;
        }

        [SecurityAspect("OutputCoil.Add", Priority = 2)]
        [ValidationAspect(typeof(OutputCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IOutputCoilService.Get", Priority = 4)]
        public async Task<IResult> Add(OutputCoil outputCoil)
        {
            await _outputCoilDal.Add(outputCoil);
            return new SuccessResult(OutputCoilMessages.Added);
        }

        [SecurityAspect("OutputCoil.Delete", Priority = 2)]
        [CacheRemoveAspect("IOutputCoilService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var outputCoilDataResult = await GetById(id);
            if (outputCoilDataResult != null)
            {
                if (outputCoilDataResult.Success)
                {
                    var outputCoil = outputCoilDataResult.Data;
                    outputCoil.IsActive = false;
                    await _outputCoilDal.Update(outputCoil);
                    return new SuccessResult(OutputCoilMessages.Deleted);
                }
            }
            return new ErrorResult(OutputCoilMessages.OperationFailed);
        }

        [SecurityAspect("OutputCoil.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<OutputCoil>>> GetAll()
        {
            var outputCoils = await _outputCoilDal.GetList(x => x.IsActive == true);
            outputCoils = outputCoils.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<OutputCoil>>(outputCoils);
        }

        [SecurityAspect("OutputCoil.GetById", Priority = 2)]
        public async Task<IDataResult<OutputCoil>> GetById(Guid id)
        {
            return new SuccessDataResult<OutputCoil>(await _outputCoilDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("OutputCoil.Search", Priority = 2)]
        public async Task<IDataResult<List<OutputCoil>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<OutputCoil>>(await _outputCoilDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("OutputCoil.Update", Priority = 2)]
        [ValidationAspect(typeof(OutputCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IOutputCoilService.Get", Priority = 4)]
        public async Task<IResult> Update(OutputCoil outputCoil)
        {
            await _outputCoilDal.Update(outputCoil);
            return new SuccessResult(OutputCoilMessages.Updated);
        }
    }
}
