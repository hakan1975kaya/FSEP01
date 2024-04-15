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
    public interface IPSIPingL22PESService
    {
        public Task<IResult> Add(PSIPingL22PES psiPingL22PES);
        public Task<IResult> Update(PSIPingL22PES psiPingL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIPingL22PES>> GetById(Guid id);
        public Task<IDataResult<List<PSIPingL22PES>>> GetAll();
        public Task<IDataResult<List<PSIPingL22PES>>> Search(FilterDto filterDto);
    }
}
