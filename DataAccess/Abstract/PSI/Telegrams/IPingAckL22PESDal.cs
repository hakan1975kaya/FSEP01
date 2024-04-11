using Core.DataAccess.Abstract;
using Entities.Concrete.Entities.PSI.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.PSI.Telegrams
{
    public interface IPingAckL22PESDal : IEntityRepositoryBase<PSIPingAckL22PES>
    {
    }
}
