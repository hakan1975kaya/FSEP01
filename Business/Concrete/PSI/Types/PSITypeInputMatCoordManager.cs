using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeInputMatCoordValidators;
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
    public class PSITypeInputMatCoordManager : IPSITypeInputMatCoordService
    {
        private IPSITypeInputMatCoordDal _psiTypeInputMatCoordDal;
        public PSITypeInputMatCoordManager(IPSITypeInputMatCoordDal psiTypeInputMatCoordDal)
        {
            _psiTypeInputMatCoordDal = psiTypeInputMatCoordDal;
        }

        [SecurityAspect("PSITypeInputMatCoord.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeInputMatCoordValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeInputMatCoordService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeInputMatCoord psiTypeInputMatCoord)
        {
            await _psiTypeInputMatCoordDal.Add(psiTypeInputMatCoord);
            return new SuccessResult(PSITypeInputMatCoordMessages.Added);
        }

        [SecurityAspect("PSITypeInputMatCoord.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeInputMatCoordService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeInputMatCoordDataResult = await GetById(id);
            if (psiTypeInputMatCoordDataResult != null)
            {
                if (psiTypeInputMatCoordDataResult.Success)
                {
                    var psiTypeInputMatCoord = psiTypeInputMatCoordDataResult.Data;
                    psiTypeInputMatCoord.IsActive = false;
                    await _psiTypeInputMatCoordDal.Update(psiTypeInputMatCoord);
                    return new SuccessResult(PSITypeInputMatCoordMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeInputMatCoordMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeInputMatCoord.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeInputMatCoord>>> GetAll()
        {
            var psiTypeInputMatCoords = await _psiTypeInputMatCoordDal.GetList(x => x.IsActive == true);
            psiTypeInputMatCoords = psiTypeInputMatCoords.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeInputMatCoord>>(psiTypeInputMatCoords);
        }

        [SecurityAspect("PSITypeInputMatCoord.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeInputMatCoord>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeInputMatCoord>(await _psiTypeInputMatCoordDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeInputMatCoord.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeInputMatCoord>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeInputMatCoord>>(await _psiTypeInputMatCoordDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeInputMatCoord.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeInputMatCoordValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeInputMatCoordService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeInputMatCoord psiTypeInputMatCoord)
        {
            await _psiTypeInputMatCoordDal.Update(psiTypeInputMatCoord);
            return new SuccessResult(PSITypeInputMatCoordMessages.Updated);
        }
    }
}
