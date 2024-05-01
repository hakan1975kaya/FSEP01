using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.PLC;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.PLC.Recipe;

namespace DataAccess.Concrete.EntityFramework.PSI.Telegrams
{
    public class EFPLCRecipeDal : EFEntityRepositoryBase<FSEP01Context, PLCRecipe>, IPLCRecipeDal
    {
    }
}
