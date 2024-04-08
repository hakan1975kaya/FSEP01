using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.General.RoleDemand
{
    public class RoleDemandDto : IDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid DemandId { get; set; }
        public string DemandName { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
