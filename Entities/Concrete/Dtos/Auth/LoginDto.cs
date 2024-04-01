using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos.Auth
{
    public class LoginDto:IDto
    {
        public int RegistrationNumber { get; set; }
        public string Password { get; set; }
    }
}
