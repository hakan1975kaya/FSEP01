using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilMachine : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public short? TransportMachineTension { get; set; }
        public short? TransportOneTension { get; set; }
        public short? TransportTwoTension { get; set; }
        public short? MachineSpeedSet { get; set; }
        public short? Acceleration { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
