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
    public class InputCoilAttachmentManager : IInputCoilAttachmentService
    {
        private IInputCoilAttachmentDal _inputCoilAttachmentDal;
        public InputCoilAttachmentManager(IInputCoilAttachmentDal inputCoilAttachmentDal)
        {
            _inputCoilAttachmentDal = inputCoilAttachmentDal;
        }

        [SecurityAspect("InputCoilAttachment.Add", Priority = 2)]
        [ValidationAspect(typeof(InputCoilAttachmentValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilAttachmentService.Get", Priority = 4)]
        public async Task<IResult> Add(InputCoilAttachment inputCoilAttachment)
        {
            await _inputCoilAttachmentDal.Add(inputCoilAttachment);
            return new SuccessResult(InputCoilAttachmentMessages.Added);
        }

        [SecurityAspect("InputCoilAttachment.Delete", Priority = 2)]
        [CacheRemoveAspect("IInputCoilAttachmentService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var inputCoilAttachmentDataResult = await GetById(id);
            if (inputCoilAttachmentDataResult != null)
            {
                if (inputCoilAttachmentDataResult.Success)
                {
                    var inputCoilAttachment = inputCoilAttachmentDataResult.Data;
                    inputCoilAttachment.IsActive = false;
                    await _inputCoilAttachmentDal.Update(inputCoilAttachment);
                    return new SuccessResult(InputCoilAttachmentMessages.Deleted);
                }
            }
            return new ErrorResult(InputCoilAttachmentMessages.OperationFailed);
        }

        [SecurityAspect("InputCoilAttachment.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<InputCoilAttachment>>> GetAll()
        {
            var inputCoilAttachments = await _inputCoilAttachmentDal.GetList(x => x.IsActive == true);
            inputCoilAttachments = inputCoilAttachments.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<InputCoilAttachment>>(inputCoilAttachments);
        }

        [SecurityAspect("InputCoilAttachment.GetById", Priority = 2)]
        public async Task<IDataResult<InputCoilAttachment>> GetById(Guid id)
        {
            return new SuccessDataResult<InputCoilAttachment>(await _inputCoilAttachmentDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("InputCoilAttachment.Search", Priority = 2)]
        public async Task<IDataResult<List<InputCoilAttachment>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<InputCoilAttachment>>(await _inputCoilAttachmentDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("InputCoilAttachment.Update", Priority = 2)]
        [ValidationAspect(typeof(InputCoilAttachmentValidator), Priority = 3)]
        [CacheRemoveAspect("IInputCoilAttachmentService.Get", Priority = 4)]
        public async Task<IResult> Update(InputCoilAttachment inputCoilAttachment)
        {
            await _inputCoilAttachmentDal.Update(inputCoilAttachment);
            return new SuccessResult(InputCoilAttachmentMessages.Updated);
        }
    }
}
