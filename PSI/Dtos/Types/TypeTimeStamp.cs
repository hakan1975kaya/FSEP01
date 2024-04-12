using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static log4net.Appender.RollingFileAppender;

namespace PSI.Dtos.Types
{
    public class TypeTimeStamp : IDto
    {
        public DateTime TimeStamp { get; set; }

    }
}

