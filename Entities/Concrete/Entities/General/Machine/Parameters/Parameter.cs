using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.Parameters
{
    public class Parameter : IEntity
    {
        public Guid Id { get; set; }
        public int RecipeNumber { get; set; }
        public string Alloy { get; set; }//80061
        public string Temper { get; set; }//1000
        public decimal ThicknessMinimum { get; set; }//0.121
        public decimal ThicknessMaximum { get; set; }//0.151
        public decimal WidthMinimum { get; set; }//1081.00
        public decimal WidthMaximum { get; set; }//1501.00
        public decimal DiameterMinimum { get; set; }//500.00
        public decimal DiameterMaximum { get; set; }//901.00
        public string UsageArea { get; set; }//INSULATION
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

