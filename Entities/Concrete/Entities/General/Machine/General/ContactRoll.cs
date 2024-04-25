using Core.Entities.Abstract;
using Entities.Concrete.Enums.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.General
{
    public class ContactRoll : IEntity//İletişim Ruloları
    {
        public Guid Id { get; set; }
        public string RollNumber { get; set; }//Rulo Numarası 431-CR-01 
        public decimal? RollDiameter { get; set; }//341.15
        public string? GroupName { get; set; }//Contact Group
        public string? RollName { get; set; }//Contact Roll (Rubber)
        public short Hardness { get; set; }//Sertlik 92
        public string? Roughness { get; set; }// Pürüzlülük1,50 - 1,70
        public RollStatusEnum Status { get; set; }//Free
        public LocationEnum Location { get; set; }//Saddle
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}