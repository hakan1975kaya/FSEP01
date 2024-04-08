using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class Parameter : IEntity
    {
        public Guid Id { get; set; }
        public string Alloy { get; set; }
        public string Temper { get; set; }
        public decimal ThicknessMin { get; set; }
        public decimal ThicknessMax { get; set; }
        public decimal WidthMin { get; set; }
        public decimal WidthMax { get; set; }
        public decimal DiameterMin { get; set; }
        public decimal DiameterMax { get; set; }
        public string UsageArea { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

