using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Event : IEntity
    {
        public Guid Id { get; set; }
        public int TNumber { get; set; }
        public string LocalId { get; set; }
        public short TType { get; set; }
        public int? IPara { get; set; }
        public float? FPara { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
