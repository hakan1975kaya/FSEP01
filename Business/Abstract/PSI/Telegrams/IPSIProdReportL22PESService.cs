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
    public interface IPSIProdReportL22PESService
    {
        public Task<IResult> Add(PSIProdReportL22PES psiProdReportL22PES);
        public Task<IResult> Update(PSIProdReportL22PES psiProdReportL22PES);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSIProdReportL22PES>> GetById(Guid id);
        public Task<IDataResult<List<PSIProdReportL22PES>>> GetAll();
        public Task<IDataResult<List<PSIProdReportL22PES>>> Search(FilterDto filterDto);
    }
}
