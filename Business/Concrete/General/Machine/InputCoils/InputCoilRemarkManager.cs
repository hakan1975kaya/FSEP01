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
    public class InputCoilRemarkManager : IInputCoilRemarkService
    {
        private IInputCoilRemarkDal _inputCoilRemarkDal;
        public InputCoilRemarkManager(IInputCoilRemarkDal inputCoilRemarkDal)
        {
            _inputCoilRemarkDal = inputCoilRemarkDal;
        }

        [SecurityAspect("InputCoilRemark.Add", Priority = 2)]
        [ValidationAspect(typeof(InputCoilRemarkValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilRemarkService.Get", Priority = 4)]
        public async Task<IResult> Add(InputCoilRemark InputCoilRemark)
        {
            await _inputCoilRemarkDal.Add(InputCoilRemark);
            return new SuccessResult(InputCoilRemarkMessages.Added);
        }

        [SecurityAspect("InputCoilRemark.Delete", Priority = 2)]
        [CacheRemoveAspect("IInputCoilRemarkService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var inputCoilRemarkDataResult = await GetById(id);
            if (inputCoilRemarkDataResult != null)
            {
                if (inputCoilRemarkDataResult.Success)
                {
                    var inputCoilRemark = inputCoilRemarkDataResult.Data;
                    inputCoilRemark.IsActive = false;
                    await _inputCoilRemarkDal.Update(inputCoilRemark);
                    return new SuccessResult(InputCoilRemarkMessages.Deleted);
                }
            }
            return new ErrorResult(InputCoilRemarkMessages.OperationFailed);
        }

        [SecurityAspect("InputCoilRemark.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<InputCoilRemark>>> GetAll()
        {
            var inputCoilRemarks = await _inputCoilRemarkDal.GetList(x => x.IsActive == true);
            inputCoilRemarks = inputCoilRemarks.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<InputCoilRemark>>(inputCoilRemarks);
        }

        [SecurityAspect("InputCoilRemark.GetById", Priority = 2)]
        public async Task<IDataResult<InputCoilRemark>> GetById(Guid id)
        {
            return new SuccessDataResult<InputCoilRemark>(await _inputCoilRemarkDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("InputCoilRemark.Search", Priority = 2)]
        public async Task<IDataResult<List<InputCoilRemark>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<InputCoilRemark>>(await _inputCoilRemarkDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("InputCoilRemark.Update", Priority = 2)]
        [ValidationAspect(typeof(InputCoilRemarkValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilRemarkService.Get", Priority = 4)]
        public async Task<IResult> Update(InputCoilRemark inputCoilRemark)
        {
            await _inputCoilRemarkDal.Update(inputCoilRemark);
            return new SuccessResult(InputCoilRemarkMessages.Updated);
        }
    }
}
