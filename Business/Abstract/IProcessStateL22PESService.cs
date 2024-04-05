using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProcessStateL22PESService
    {
        public Task<IResult> Add(ProcessStateL22PES ProcessStateL22PES);
        public Task<IResult> Update(ProcessStateL22PES ProcessStateL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ProcessStateL22PES>> GetById(Guid id);
        public Task<IDataResult<List<ProcessStateL22PES>>> GetAll ();
        public Task<IDataResult<List<ProcessStateL22PES>>> Search(FilterDto filterDto);
    }
}
