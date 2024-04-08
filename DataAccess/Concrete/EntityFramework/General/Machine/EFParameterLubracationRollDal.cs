using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine
{
    public class EFParameterLubracationRollDal:EFEntityRepositoryBase<FSEP01Context, ParameterLubracationRoll>, IParameterLubracationRollDal
    {
    }
}
