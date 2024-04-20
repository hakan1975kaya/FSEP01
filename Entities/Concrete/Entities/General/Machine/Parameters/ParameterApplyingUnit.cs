using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.Parameters
{
    public class ParameterApplyingUnit : IEntity
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public bool? LubricatorAutoOn { get; set; }
        public decimal? RelativeApplyingSpeedSet { get; set; }
        public decimal? MinimumApplyingSpeedSet { get; set; }
        public decimal? ApplyingUnitTempTrayOneSet { get; set; }
        public decimal? ApplyingUnitTempTrayTwoSet { get; set; }
        public short? PressureAROneLeftSideSet { get; set; }
        public short? PressureAROneRightSideSet { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
