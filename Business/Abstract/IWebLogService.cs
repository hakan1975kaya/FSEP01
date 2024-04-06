using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWebLogService
    {
        public Task<IResult> Add(WebLog webLog);
        public Task<IResult> Update(WebLog webLog);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<WebLog>> GetById(Guid id);
        public Task<IDataResult<List<WebLog>>> GetAll();
        public Task<IDataResult<List<WebLog>>> Search(FilterDto filterDto);
    }
}
