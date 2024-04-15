using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeParameterListValidators;
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
    public class PSITypeParameterListManager : IPSITypeParameterListService
    {
        private IPSITypeParameterListDal _psiTypeParameterListDal;
        public PSITypeParameterListManager(IPSITypeParameterListDal psiTypeParameterListDal)
        {
            _psiTypeParameterListDal = psiTypeParameterListDal;
        }

        [SecurityAspect("PSITypeParameterList.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeParameterListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeParameterListService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeParameterList psiTypeParameterList)
        {
            await _psiTypeParameterListDal.Add(psiTypeParameterList);
            return new SuccessResult(PSITypeParameterListMessages.Added);
        }

        [SecurityAspect("PSITypeParameterList.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeParameterListService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeParameterListDataResult = await GetById(id);
            if (psiTypeParameterListDataResult != null)
            {
                if (psiTypeParameterListDataResult.Success)
                {
                    var psiTypeParameterList = psiTypeParameterListDataResult.Data;
                    psiTypeParameterList.IsActive = false;
                    await _psiTypeParameterListDal.Update(psiTypeParameterList);
                    return new SuccessResult(PSITypeParameterListMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeParameterListMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeParameterList.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeParameterList>>> GetAll()
        {
            var psiTypeParameterLists = await _psiTypeParameterListDal.GetList(x => x.IsActive == true);
            psiTypeParameterLists = psiTypeParameterLists.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeParameterList>>(psiTypeParameterLists);
        }

        [SecurityAspect("PSITypeParameterList.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeParameterList>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeParameterList>(await _psiTypeParameterListDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeParameterList.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeParameterList>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeParameterList>>(await _psiTypeParameterListDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeParameterList.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeParameterListValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeParameterListService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeParameterList psiTypeParameterList)
        {
            await _psiTypeParameterListDal.Update(psiTypeParameterList);
            return new SuccessResult(PSITypeParameterListMessages.Updated);
        }
    }
}
