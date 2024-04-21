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
    public class InputCoilManager : IInputCoilService
    {
        private IInputCoilDal _inputCoilDal;
        public InputCoilManager(IInputCoilDal inputCoilDal)
        {
            _inputCoilDal = inputCoilDal;
        }

        [SecurityAspect("InputCoil.Add", Priority = 2)]
        [ValidationAspect(typeof(InputCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilService.Get", Priority = 4)]
        public async Task<IResult> Add(InputCoil inputCoil)
        {
            await _inputCoilDal.Add(inputCoil);
            return new SuccessResult(InputCoilMessages.Added);
        }

        [SecurityAspect("InputCoil.Delete", Priority = 2)]
        [CacheRemoveAspect("IInputCoilService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var inputCoilDataResult = await GetById(id);
            if (inputCoilDataResult != null)
            {
                if (inputCoilDataResult.Success)
                {
                    var inputCoil = inputCoilDataResult.Data;
                    inputCoil.IsActive = false;
                    await _inputCoilDal.Update(inputCoil);
                    return new SuccessResult(InputCoilMessages.Deleted);
                }
            }
            return new ErrorResult(InputCoilMessages.OperationFailed);
        }

        [SecurityAspect("InputCoil.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<InputCoil>>> GetAll()
        {
            var inputCoils = await _inputCoilDal.GetList(x => x.IsActive == true);
            inputCoils = inputCoils.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<InputCoil>>(inputCoils);
        }

        [SecurityAspect("InputCoil.GetById", Priority = 2)]
        public async Task<IDataResult<InputCoil>> GetById(Guid id)
        {
            return new SuccessDataResult<InputCoil>(await _inputCoilDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("InputCoil.Search", Priority = 2)]
        public async Task<IDataResult<List<InputCoil>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<InputCoil>>(await _inputCoilDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("InputCoil.Update", Priority = 2)]
        [ValidationAspect(typeof(InputCoilValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilService.Get", Priority = 4)]
        public async Task<IResult> Update(InputCoil inputCoil)
        {
            await _inputCoilDal.Update(inputCoil);
            return new SuccessResult(InputCoilMessages.Updated);
        }
    }
}
