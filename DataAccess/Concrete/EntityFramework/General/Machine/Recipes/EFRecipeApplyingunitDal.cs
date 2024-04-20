using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.Recipes;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.Recipes
{
    public class EFRecipeApplyingunitDal:EFEntityRepositoryBase<FSEP01Context, RecipeApplyingunit>, IRecipeApplyingunitDal
    {
    }
}
