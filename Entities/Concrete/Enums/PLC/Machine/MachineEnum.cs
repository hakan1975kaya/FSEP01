using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Enums.PLC.Machine
{
    public enum MachineEnum
    {
        EStop = 0,
        Stop = 1,
        Release = 2,
        Jog = 3,
        BaseSpeed = 4,
        Run = 5,
        LimitActive = 6
    }
}
