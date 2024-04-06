using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General
{
    public interface IUserDal : IEntityRepositoryBase<User>
    {
        public Task<List<Demand>> GetDemandsByUserId(Guid userId);
        public Task<List<Menu>> GetMenusByUserId(Guid userId);
    }
}
