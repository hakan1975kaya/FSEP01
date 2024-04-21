using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.Parameters;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.Parameters
{
    public class EFParameterSuctionDal:EFEntityRepositoryBase<FSEP01Context, ParameterSuction>, IParameterSuctionDal
    {
    }
}
