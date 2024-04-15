using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PSI.Telegrams
{
    public interface IPSIRequestProcessDataL22PESService
    {
        public Task<IResult> Add(PSIRequestProcessDataL22PES psiRequestProcessDataL22PES);
        public Task<IResult> Update(PSIRequestProcessDataL22PES psiRequestProcessDataL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIRequestProcessDataL22PES>> GetById(Guid id);
        public Task<IDataResult<List<PSIRequestProcessDataL22PES>>> GetAll();
        public Task<IDataResult<List<PSIRequestProcessDataL22PES>>> Search(FilterDto filterDto);
    }
}
