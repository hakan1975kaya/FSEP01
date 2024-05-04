using Core.DataAccess.Abstract;
using Entities.Concrete.Entities.PLC.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.PLC.Recipe
{
    public interface IPLCRecipeDal : IEntityRepositoryBase<PLCRecipe>
    {
    }
}
