using Core.Entities.Abstract;
using Entities.Concrete.Enums.General.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.General
{
    public class ApiLog : IEntity
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public AuditEnum Audit { get; set; }
    }
}
