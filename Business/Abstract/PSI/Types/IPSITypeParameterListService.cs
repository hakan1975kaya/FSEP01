using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeParameterListService
    {
        public Task<IResult> Add(PSITypeParameterList psiTypeParameterList);
        public Task<IResult> Update(PSITypeParameterList psiTypeParameterList);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeParameterList>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeParameterList>>> GetAll();
        public Task<IDataResult<List<PSITypeParameterList>>> Search(FilterDto filterDto);
    }
}
