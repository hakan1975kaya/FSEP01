using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeMachineService
    {
        public Task<IResult> Add(RecipeMachine recipeMachine);
        public Task<IResult> Update(RecipeMachine recipeMachine);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeMachine>> GetById(Guid id);
        public Task<IDataResult<List<RecipeMachine>>> GetAll();
        public Task<IDataResult<List<RecipeMachine>>> Search(FilterDto filterDto);
    }
}
