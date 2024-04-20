﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.Recipes
{
    public class RecipeApplyingUnit : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string LocalId { get; set; }
        public string Alloy { get; set; }
        public string Temper { get; set; }
        public decimal Thickness { get; set; }
        public decimal Width { get; set; }
        public decimal Diameter { get; set; }
        public string UsageAreaId { get; set; }
        public bool? LubricatorAutoOn { get; set; }
        public decimal? RelativeApplyingSpeedSet { get; set; }
        public decimal? MinimumApplyingSpeedSet { get; set; }
        public decimal? ApplyingUnitTempTrayOneSet { get; set; }
        public decimal? ApplyingUnitTempTrayTwoSet { get; set; }
        public short? PressureAROneLeftSideSet { get; set; }
        public short? PressureAROneRightSideSet { get; set; }
        public DateTime Optime { get; set; }//2023-06-03 00:20:45
        public bool IsActive { get; set; }
    }
}
