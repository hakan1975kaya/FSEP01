using PLC.Entities;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Helper
{
    public interface IPlcHelper
    {
        Plc Plc();
    }
}
