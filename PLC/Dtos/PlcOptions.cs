using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Dtos
{
    public class PLCOptions
    {
        public string IP { get; set; }
        public CpuType CpuType { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public int ReadTimeout { get; set; }
        public int WriteTimeout { get; set; }

    }
}
