using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Event : IEntity//etkinlik
    {
        public Guid Id { get; set; }
        public int TNumber { get; set; }//201
        public string LocalId { get; set; }//123040192.02.01
        public short TType { get; set; }//2
        public int? IPara { get; set; }//0
        public float? FPara { get; set; }//0
        public DateTime Optime { get; set; }//2023-06-03 00:20:45
        public bool IsActive { get; set; }
    }
}
