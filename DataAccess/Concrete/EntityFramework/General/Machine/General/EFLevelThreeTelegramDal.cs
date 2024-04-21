using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.General;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.General
{
    public class EFLevelThreeTelegramDal:EFEntityRepositoryBase<FSEP01Context, LevelThreeTelegram>, ILevelThreeTelegramDal
    {
    }
}
