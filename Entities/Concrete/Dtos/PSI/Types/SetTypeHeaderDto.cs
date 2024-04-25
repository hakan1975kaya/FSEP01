using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.PSI.Types
{
    public class SetTypeHeaderDto : IDto
    {
        public TypeHeader typeHeader { get; set; }
        public Guid psiTypeHeaderId { get; set; }
        public Guid psiTypeTimeStampId { get; set; }
    }
}
