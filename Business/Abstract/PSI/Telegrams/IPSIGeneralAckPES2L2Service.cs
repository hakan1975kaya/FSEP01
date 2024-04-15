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
    public interface IPSIGeneralAckPES2L2Service
    {
        public Task<IResult> Add(PSIGeneralAckPES2L2 psiGeneralAckPES2L2);
        public Task<IResult> Update(PSIGeneralAckPES2L2 psiGeneralAckPES2L2);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIGeneralAckPES2L2>> GetById(Guid id);
        public Task<IDataResult<List<PSIGeneralAckPES2L2>>> GetAll();
        public Task<IDataResult<List<PSIGeneralAckPES2L2>>> Search(FilterDto filterDto);
    }
}
