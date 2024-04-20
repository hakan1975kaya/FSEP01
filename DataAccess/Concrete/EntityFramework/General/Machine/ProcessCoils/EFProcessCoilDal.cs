using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.ProcessCoils;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.ProcessCoils
{
    public class EFProcessCoilDal:EFEntityRepositoryBase<FSEP01Context, ProcessCoil>, IProcessCoilDal
    {
    }
}
