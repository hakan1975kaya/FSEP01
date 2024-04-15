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
    public interface IPSIPingAckPES2L2Service
    {
        public Task<IResult> Add(PSIPingAckPES2L2 psiPingAckPES2L2);
        public Task<IResult> Update(PSIPingAckPES2L2 psiPingAckPES2L2);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIPingAckPES2L2>> GetById(Guid id);
        public Task<IDataResult<List<PSIPingAckPES2L2>>> GetAll();
        public Task<IDataResult<List<PSIPingAckPES2L2>>> Search(FilterDto filterDto);
    }
}
