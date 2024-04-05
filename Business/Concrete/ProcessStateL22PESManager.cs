using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.AuthValidators;
using Business.Validators.FluentValidators.ProcessStateL22PESValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Entities;
using System.Linq;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ProcessStateL22PESManager : IProcessStateL22PESService
    {
        private IProcessStateL22PESDal _ProcessStateL22PESDal;
        public ProcessStateL22PESManager(IProcessStateL22PESDal ProcessStateL22PESDal)
        {
            _ProcessStateL22PESDal = ProcessStateL22PESDal;
        }

        [SecurityAspect("ProcessStateL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(ProcessStateL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IProcessStateL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(ProcessStateL22PES ProcessStateL22PES)
        {
            await _ProcessStateL22PESDal.Add(ProcessStateL22PES);
            return new SuccessResult(ProcessStateL22PESMessages.Added);
        }

        [SecurityAspect("ProcessStateL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IProcessStateL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var ProcessStateL22PESDataResult = await GetById(id);
            if (ProcessStateL22PESDataResult != null)
            {
                if (ProcessStateL22PESDataResult.Success)
                {
                    var ProcessStateL22PES = ProcessStateL22PESDataResult.Data;
                    ProcessStateL22PES.IsActive = false;
                    await _ProcessStateL22PESDal.Update(ProcessStateL22PES);
                    return new SuccessResult(ProcessStateL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(ProcessStateL22PESMessages.OperationFailed);
        }

        [SecurityAspect("ProcessStateL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ProcessStateL22PES>>> GetAll()
        {
            var ProcessStateL22PESs = await _ProcessStateL22PESDal.GetList(x => x.IsActive == true);
            ProcessStateL22PESs=ProcessStateL22PESs.OrderBy(x=>x.ProcessStateL22PESName).ToList();
            return new SuccessDataResult<List<ProcessStateL22PES>>(ProcessStateL22PESs);
        }

        [SecurityAspect("ProcessStateL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<ProcessStateL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<ProcessStateL22PES>(await _ProcessStateL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ProcessStateL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<ProcessStateL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ProcessStateL22PES>>(await _ProcessStateL22PESDal.GetList(x => x.IsActive == true && (x.Optime.ToString().Contains(filterDto.Filter) || x.ProcessStateL22PESName.Contains(filterDto.Filter))));
        }

        [SecurityAspect("ProcessStateL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(ProcessStateL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IProcessStateL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(ProcessStateL22PES ProcessStateL22PES)
        {
            await _ProcessStateL22PESDal.Update(ProcessStateL22PES);
            return new SuccessResult(ProcessStateL22PESMessages.Updated);
        }
    }
}
