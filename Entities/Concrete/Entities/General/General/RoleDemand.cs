using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.General
{
    public class RoleDemand : IEntity
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid DemandId { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

