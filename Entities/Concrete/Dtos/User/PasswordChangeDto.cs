using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.User
{
    public class PasswordChangeDto
    {
        public int RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
