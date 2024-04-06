using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Dtos.RoleMenu;
using Entities.Concrete.Entities.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleMenuService
    {
        public Task<IResult> Add(RoleMenu roleMenu);
        public Task<IResult> Update(RoleMenu roleMenu);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RoleMenu>> GetById(Guid id);
        public Task<IDataResult<List<RoleMenu>>> GetAll ();
        public Task<IDataResult<List<RoleMenuDto>>> Search(FilterDto filterDto);
    }
}
