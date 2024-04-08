﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class InputCoilSuction : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public short? PrecutterRpmSet { get; set; }
        public bool? PrecutterSpeedSet { get; set; }
        public bool? PrecutterOneTwoOnOff { get; set; }
        public short? SuctionRpmSet { get; set; }
        public short? SuctionSpeedSet { get; set; }
        public bool? BoosterSortOneOnOff { get; set; }
        public bool? BoosterSortTwoOnOff { get; set; }
        public bool? BoosterSortThreeOnOff { get; set; }
        public short? AirFlapOneSet { get; set; }
        public short? AirFlapTwoSet { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
