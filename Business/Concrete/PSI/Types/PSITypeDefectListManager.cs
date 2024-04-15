using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeDefectListValidators;
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
    public class PSITypeDefectListManager : IPSITypeDefectListService
    {
        private IPSITypeDefectListDal _psiTypeDefectListDal;
        public PSITypeDefectListManager(IPSITypeDefectListDal psiTypeDefectListDal)
        {
            _psiTypeDefectListDal = psiTypeDefectListDal;
        }

        [SecurityAspect("PSITypeDefectList.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeDefectListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeDefectListService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeDefectList psiTypeDefectList)
        {
            await _psiTypeDefectListDal.Add(psiTypeDefectList);
            return new SuccessResult(PSITypeDefectListMessages.Added);
        }

        [SecurityAspect("PSITypeDefectList.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeDefectListService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeDefectListDataResult = await GetById(id);
            if (psiTypeDefectListDataResult != null)
            {
                if (psiTypeDefectListDataResult.Success)
                {
                    var psiTypeDefectList = psiTypeDefectListDataResult.Data;
                    psiTypeDefectList.IsActive = false;
                    await _psiTypeDefectListDal.Update(psiTypeDefectList);
                    return new SuccessResult(PSITypeDefectListMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeDefectListMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeDefectList.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeDefectList>>> GetAll()
        {
            var psiTypeDefectLists = await _psiTypeDefectListDal.GetList(x => x.IsActive == true);
            psiTypeDefectLists = psiTypeDefectLists.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeDefectList>>(psiTypeDefectLists);
        }

        [SecurityAspect("PSITypeDefectList.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeDefectList>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeDefectList>(await _psiTypeDefectListDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeDefectList.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeDefectList>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeDefectList>>(await _psiTypeDefectListDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeDefectList.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeDefectListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeDefectListService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeDefectList psiTypeDefectList)
        {
            await _psiTypeDefectListDal.Update(psiTypeDefectList);
            return new SuccessResult(PSITypeDefectListMessages.Updated);
        }
    }
}
