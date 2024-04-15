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
    public interface IPSIPingAckL22PESService
    {
        public Task<IResult> Add(PSIPingAckL22PES psiPingAckL22PES);
        public Task<IResult> Update(PSIPingAckL22PES psiPingAckL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIPingAckL22PES>> GetById(Guid id);
        public Task<IDataResult<List<PSIPingAckL22PES>>> GetAll();
        public Task<IDataResult<List<PSIPingAckL22PES>>> Search(FilterDto filterDto);
    }
}
