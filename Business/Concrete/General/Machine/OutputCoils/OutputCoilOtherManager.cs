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
    public class OutputCoilOtherManager : IOutputCoilOtherService
    {
        private IOutputCoilOtherDal _outputCoilOtherDal;
        public OutputCoilOtherManager(IOutputCoilOtherDal outputCoilOtherDal)
        {
            _outputCoilOtherDal = outputCoilOtherDal;
        }

        [SecurityAspect("OutputCoilOther.Add", Priority = 2)]
        [ValidationAspect(typeof(OutputCoilOtherValidator), Priority = 3)]
        [CacheRemoveAspect("IOutputCoilOtherService.Get", Priority = 4)]
        public async Task<IResult> Add(OutputCoilOther outputCoilOther)
        {
            await _outputCoilOtherDal.Add(outputCoilOther);
            return new SuccessResult(OutputCoilOtherMessages.Added);
        }

        [SecurityAspect("OutputCoilOther.Delete", Priority = 2)]
        [CacheRemoveAspect("IOutputCoilOtherService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var outputCoilOtherDataResult = await GetById(id);
            if (outputCoilOtherDataResult != null)
            {
                if (outputCoilOtherDataResult.Success)
                {
                    var outputCoilOther = outputCoilOtherDataResult.Data;
                    outputCoilOther.IsActive = false;
                    await _outputCoilOtherDal.Update(outputCoilOther);
                    return new SuccessResult(OutputCoilOtherMessages.Deleted);
                }
            }
            return new ErrorResult(OutputCoilOtherMessages.OperationFailed);
        }

        [SecurityAspect("OutputCoilOther.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<OutputCoilOther>>> GetAll()
        {
            var outputCoilOthers = await _outputCoilOtherDal.GetList(x => x.IsActive == true);
            outputCoilOthers = outputCoilOthers.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<OutputCoilOther>>(outputCoilOthers);
        }

        [SecurityAspect("OutputCoilOther.GetById", Priority = 2)]
        public async Task<IDataResult<OutputCoilOther>> GetById(Guid id)
        {
            return new SuccessDataResult<OutputCoilOther>(await _outputCoilOtherDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("OutputCoilOther.Search", Priority = 2)]
        public async Task<IDataResult<List<OutputCoilOther>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<OutputCoilOther>>(await _outputCoilOtherDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("OutputCoilOther.Update", Priority = 2)]
        [ValidationAspect(typeof(OutputCoilOtherValidator), Priority = 3)]
        [CacheRemoveAspect("IOutputCoilOtherService.Get", Priority = 4)]
        public async Task<IResult> Update(OutputCoilOther outputCoilOther)
        {
            await _outputCoilOtherDal.Update(outputCoilOther);
            return new SuccessResult(OutputCoilOtherMessages.Updated);
        }
    }
}
