using Core.DataAccess.Abstract;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General.Machine.ProcessCoils
{
    public interface IProcessCoilDal:IEntityRepositoryBase<ProcessCoil>
    {
    }
}
