using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General
{
    public interface IApiLogService
    {
        public Task<IResult> Add(ApiLog apiLog);
        public Task<IResult> Update(ApiLog apiLog);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ApiLog>> GetById(Guid id);
        public Task<IDataResult<List<ApiLog>>> GetAll();
        public Task<IDataResult<List<ApiLog>>> Search(FilterDto filterDto);//
    }
}
