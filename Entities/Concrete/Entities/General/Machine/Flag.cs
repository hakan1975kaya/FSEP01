using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Flag : IEntity
    {
        public Guid Id { get; set; }
        public string FlagName { get; set; }
        public bool FlagValue { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
