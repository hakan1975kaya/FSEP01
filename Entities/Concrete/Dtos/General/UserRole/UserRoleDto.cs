using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.General.UserRole
{
    public class UserRoleDto : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
