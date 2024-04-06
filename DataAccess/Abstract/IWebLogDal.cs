using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete.Entities.WEB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWebLogDal : IEntityRepositoryBase<WebLog>
    {
    }
}
