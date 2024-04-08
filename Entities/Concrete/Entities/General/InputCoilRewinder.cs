﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class InputCoilRewinder : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public decimal? RewinderOneTensionSetPoint { get; set; }
        public decimal? RewinderOneContactPreSetPoint { get; set; }
        public bool? RewinderOneGapMode { get; set; }
        public bool? RewinderOneContactPositionMode { get; set; }
        public bool? RewinderOneContactForceMode { get; set; }
        public bool? RewinderOnePreSelectionOn { get; set; }
        public bool? RewinderOnePreSelectionOff { get; set; }
        public bool? RewinderTwoTensionSetPoint { get; set; }
        public bool? RewinderTwoContactPreSetPoint { get; set; }
        public bool? RewinderTwoGapMode { get; set; }
        public bool? RewinderTwoContactPositionMode { get; set; }
        public bool? RewinderTwoContactForceMode { get; set; }
        public bool? RewinderTwoPreSelectionOn { get; set; }
        public bool? RewinderTwoPreSelectionOff { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
