using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDemandService
    {
        public Task<IResult> Add(Demand demand);
        public Task<IResult> Update(Demand demand);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Demand>> GetById(Guid id);
        public Task<IDataResult<List<Demand>>> GetAll ();
        public Task<IDataResult<List<Demand>>> Search(FilterDto filterDto);
    }
}
