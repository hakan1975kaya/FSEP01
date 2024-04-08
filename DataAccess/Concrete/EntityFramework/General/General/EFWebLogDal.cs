using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.General;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.General
{
    public class EFWebLogDal : EFEntityRepositoryBase<FSEP01LOGContext, WebLog>, IWebLogDal
    {

    }
}
