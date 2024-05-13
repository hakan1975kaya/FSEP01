using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine;

namespace DataAccess.Concrete.EntityFramework.General.Machine
{
    public class EFEntryCoilDal:EFEntityRepositoryBase<FSEP01Context,EntryCoil>,IEntryCoilDal
    {
    }
}
