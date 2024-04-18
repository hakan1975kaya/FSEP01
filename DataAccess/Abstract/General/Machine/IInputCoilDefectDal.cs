using Core.DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.General.Machine
{
    public interface IInputCoilDefectDal : IEntityRepositoryBase<InputCoilDefect>
    {
    }
}
