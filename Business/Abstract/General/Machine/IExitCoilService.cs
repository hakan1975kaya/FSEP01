using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General.General
{
    public interface IExitCoilService
    {
        public Task<IResult> Add(ExitCoil exitCoil);
        public Task<IResult> Update(ExitCoil exitCoil);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ExitCoil>> GetById(Guid id);
        public Task<IDataResult<List<ExitCoil>>> GetAll();
        public Task<IDataResult<List<ExitCoil>>> Search(FilterDto filterDto);
    }
}
