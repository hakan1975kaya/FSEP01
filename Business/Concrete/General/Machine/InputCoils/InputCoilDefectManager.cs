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
using DataAccess.Abstract.General.Machine.InputCoils;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class InputCoilDefectManager : IInputCoilDefectService
    {
        private IInputCoilDefectDal _inputCoilDefectDal;
        public InputCoilDefectManager(IInputCoilDefectDal inputCoilDefectDal)
        {
            _inputCoilDefectDal = inputCoilDefectDal;
        }

        [SecurityAspect("InputCoilDefect.Add", Priority = 2)]
        [ValidationAspect(typeof(InputCoilDefectValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilDefectService.Get", Priority = 4)]
        public async Task<IResult> Add(InputCoilDefect inputCoilDefect)
        {
            await _inputCoilDefectDal.Add(inputCoilDefect);
            return new SuccessResult(InputCoilDefectMessages.Added);
        }

        [SecurityAspect("InputCoilDefect.Delete", Priority = 2)]
        [CacheRemoveAspect("IInputCoilDefectService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var inputCoilDefectDataResult = await GetById(id);
            if (inputCoilDefectDataResult != null)
            {
                if (inputCoilDefectDataResult.Success)
                {
                    var inputCoilDefect = inputCoilDefectDataResult.Data;
                    inputCoilDefect.IsActive = false;
                    await _inputCoilDefectDal.Update(inputCoilDefect);
                    return new SuccessResult(InputCoilDefectMessages.Deleted);
                }
            }
            return new ErrorResult(InputCoilDefectMessages.OperationFailed);
        }

        [SecurityAspect("InputCoilDefect.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<InputCoilDefect>>> GetAll()
        {
            var inputCoilDefects = await _inputCoilDefectDal.GetList(x => x.IsActive == true);
            inputCoilDefects = inputCoilDefects.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<InputCoilDefect>>(inputCoilDefects);
        }

        [SecurityAspect("InputCoilDefect.GetById", Priority = 2)]
        public async Task<IDataResult<InputCoilDefect>> GetById(Guid id)
        {
            return new SuccessDataResult<InputCoilDefect>(await _inputCoilDefectDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("InputCoilDefect.Search", Priority = 2)]
        public async Task<IDataResult<List<InputCoilDefect>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<InputCoilDefect>>(await _inputCoilDefectDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("InputCoilDefect.Update", Priority = 2)]
        [ValidationAspect(typeof(InputCoilDefectValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilDefectService.Get", Priority = 4)]
        public async Task<IResult> Update(InputCoilDefect inputCoilDefect)
        {
            await _inputCoilDefectDal.Update(inputCoilDefect);
            return new SuccessResult(InputCoilDefectMessages.Updated);
        }
    }
}
