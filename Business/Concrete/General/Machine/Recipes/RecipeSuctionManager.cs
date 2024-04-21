using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.Machine.Recipe;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.Recipes;
using DataAccess.Concrete.EntityFramework.General.Machine.Recipes;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class RecipeSuctionManager : IRecipeSuctionService
    {
        private IRecipeSuctionDal _recipeSuctionDal;
        public RecipeSuctionManager(EFRecipeSuctionDal recipeSuctionDal)
        {
            _recipeSuctionDal = recipeSuctionDal;
        }

        [SecurityAspect("RecipeSuction.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeSuctionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeSuctionService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeSuction recipeSuction)
        {
            await _recipeSuctionDal.Add(recipeSuction);
            return new SuccessResult(RecipeSuctionMessages.Added);
        }

        [SecurityAspect("RecipeSuction.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeSuctionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeSuctionDataResult = await GetById(id);
            if (recipeSuctionDataResult != null)
            {
                if (recipeSuctionDataResult.Success)
                {
                    var recipeSuction = recipeSuctionDataResult.Data;
                    recipeSuction.IsActive = false;
                    await _recipeSuctionDal.Update(recipeSuction);
                    return new SuccessResult(RecipeSuctionMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeSuctionMessages.OperationFailed);
        }

        [SecurityAspect("RecipeSuction.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeSuction>>> GetAll()
        {
            var recipeSuctions = await _recipeSuctionDal.GetList(x => x.IsActive == true);
            recipeSuctions = recipeSuctions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeSuction>>(recipeSuctions);
        }

        [SecurityAspect("RecipeSuction.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeSuction>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeSuction>(await _recipeSuctionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeSuction.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeSuction>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeSuction>>(await _recipeSuctionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeSuction.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeSuctionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeSuctionService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeSuction recipeSuction)
        {
            await _recipeSuctionDal.Update(recipeSuction);
            return new SuccessResult(RecipeSuctionMessages.Updated);
        }
    }
}
