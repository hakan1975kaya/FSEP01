using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General.Machine
{
    public interface IEntryCoilService
    {
        public Task<IResult> Add(EntryCoil entryCoil);
        public Task<IResult> Update(EntryCoil entryCoil);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<EntryCoil>> GetById(Guid id);
        public Task<IDataResult<List<EntryCoil>>> GetAll();
        public Task<IDataResult<List<EntryCoil>>> Search(FilterDto filterDto);
    }
}
