using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PLC.Recipe;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PLC.Recipe;

namespace DataAccess.Concrete.EntityFramework.PLC.Recipe
{
    public class EFPLCRecipeDal : EFEntityRepositoryBase<FSEP01Context, PLCRecipe>, IPLCRecipeDal
    {
    }
}
