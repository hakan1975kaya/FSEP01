using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.General
{
    public interface IMenuService
    {
        public Task<IResult> Add(Menu menu);
        public Task<IResult> Update(Menu menu);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Menu>> GetById(Guid id);
        public Task<IDataResult<List<Menu>>> GetAll();
        public Task<IDataResult<List<Menu>>> Search(FilterDto filterDto);
    }
}
