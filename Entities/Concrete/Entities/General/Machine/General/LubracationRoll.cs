﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.General
{
    public class LubracationRoll : IEntity//Yağlama Rulosu
    {
        public Guid Id { get; set; }
        public string? RollNumber { get; set; }
        public decimal? RollDiameter { get; set; }
        public string? GroupName { get; set; }
        public string? RollName { get; set; }
        public short? Hardness { get; set; }//Sertlik
        public string? Roughness { get; set; }//Pürüzlülük
        public string? Status { get; set; }
        public string? Location { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
