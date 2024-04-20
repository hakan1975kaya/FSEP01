using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.OutputCoils;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.OutputCoils
{
    public class EFOutputCoilDal:EFEntityRepositoryBase<FSEP01Context, OutputCoil>, IOutputCoilDal
    {
    }
}
