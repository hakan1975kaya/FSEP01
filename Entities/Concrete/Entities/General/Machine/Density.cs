using Core.Entities.Abstract;
using Entities.Concrete.Entities.General.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Density : IEntity//Yoğunluk
    {
        public Guid Id { get; set; }
        public string? Alloy { get; set; }// Alaşım 10500
        public float? Value { get; set; }//2.705
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
