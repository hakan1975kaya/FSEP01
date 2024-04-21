using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract.General.Machine.InputCoils;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.General.Machine.InputCoils
{
    public class EFInputCoilAttachmentDal : EFEntityRepositoryBase<FSEP01Context, InputCoilAttachment>, IInputCoilAttachmentDal
    {
    }
}
