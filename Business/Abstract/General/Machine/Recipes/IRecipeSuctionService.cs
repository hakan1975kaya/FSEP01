using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeSuctionService
    {
        public Task<IResult> Add(RecipeSuction recipeSuction);
        public Task<IResult> Update(RecipeSuction recipeSuction);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeSuction>> GetById(Guid id);
        public Task<IDataResult<List<RecipeSuction>>> GetAll();
        public Task<IDataResult<List<RecipeSuction>>> Search(FilterDto filterDto);
    }
}
