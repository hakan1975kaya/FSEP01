using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General
{
    public interface IWebLogDal : IEntityRepositoryBase<WebLog>
    {
    }
}
