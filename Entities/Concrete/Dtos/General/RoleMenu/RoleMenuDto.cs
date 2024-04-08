using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.General.RoleMenu
{
    public class RoleMenuDto : IDto
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int MenuOrder { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
