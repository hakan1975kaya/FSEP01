using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeDefectActionListValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Types;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;


namespace Business.Concrete.PSI.Telegrams
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PSITypeDefectActionListManager : IPSITypeDefectActionListService
    {
        private IPSITypeDefectActionListDal _psiTypeDefectActionListDal;
        public PSITypeDefectActionListManager(IPSITypeDefectActionListDal psiTypeDefectActionListDal)
        {
            _psiTypeDefectActionListDal = psiTypeDefectActionListDal;
        }

        [SecurityAspect("PSITypeDefectActionList.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeDefectActionListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeDefectActionListService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeDefectActionList psiTypeDefectActionList)
        {
            await _psiTypeDefectActionListDal.Add(psiTypeDefectActionList);
            return new SuccessResult(PSITypeDefectActionListMessages.Added);
        }

        [SecurityAspect("PSITypeDefectActionList.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeDefectActionListService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeDefectActionListDataResult = await GetById(id);
            if (psiTypeDefectActionListDataResult != null)
            {
                if (psiTypeDefectActionListDataResult.Success)
                {
                    var psiTypeDefectActionList = psiTypeDefectActionListDataResult.Data;
                    psiTypeDefectActionList.IsActive = false;
                    await _psiTypeDefectActionListDal.Update(psiTypeDefectActionList);
                    return new SuccessResult(PSITypeDefectActionListMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeDefectActionListMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeDefectActionList.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeDefectActionList>>> GetAll()
        {
            var psiTypeDefectActionLists = await _psiTypeDefectActionListDal.GetList(x => x.IsActive == true);
            psiTypeDefectActionLists = psiTypeDefectActionLists.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeDefectActionList>>(psiTypeDefectActionLists);
        }

        [SecurityAspect("PSITypeDefectActionList.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeDefectActionList>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeDefectActionList>(await _psiTypeDefectActionListDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeDefectActionList.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeDefectActionList>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeDefectActionList>>(await _psiTypeDefectActionListDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeDefectActionList.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeDefectActionListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeDefectActionListService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeDefectActionList psiTypeDefectActionList)
        {
            await _psiTypeDefectActionListDal.Update(psiTypeDefectActionList);
            return new SuccessResult(PSITypeDefectActionListMessages.Updated);
        }
    }
}
