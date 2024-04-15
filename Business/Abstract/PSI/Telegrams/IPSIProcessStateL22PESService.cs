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
    public interface IPSIProcessStateL22PESService
    {
        public Task<IResult> Add(PSIProcessStateL22PES PSİProcessStateL22PES);
        public Task<IResult> Update(PSIProcessStateL22PES PSİProcessStateL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIProcessStateL22PES>> GetById(Guid id);
        public Task<IDataResult<List<PSIProcessStateL22PES>>> GetAll();
        public Task<IDataResult<List<PSIProcessStateL22PES>>> Search(FilterDto filterDto);
    }
}
