using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PSI.Types;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PSI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.PSI.Types
{
    public class EFPSITypeOutputMatDal : EFEntityRepositoryBase<FSEP01Context, PSITypeOutputMat>, IPSITypeOutputMatDal
    {
    }
}
