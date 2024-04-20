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
        public string Alloy { get; set; }//80061
        public string Temper { get; set; }//1000
        public decimal ThicknessMin { get; set; }//0.121
        public decimal ThicknessMax { get; set; }//0.151
        public decimal WidthMin { get; set; }//1081.00
        public decimal WidthMax { get; set; }//1501.00
        public decimal DiameterMin { get; set; }//500.00
        public decimal DiameterMax { get; set; }//901.00
        public string UsageArea { get; set; }//INSULATION
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

