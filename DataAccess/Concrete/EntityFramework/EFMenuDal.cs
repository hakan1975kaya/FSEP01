using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFMenuDal:EFEntityRepositoryBase<FSEPContext,Menu>,IMenuDal
    {
    
    }
}
