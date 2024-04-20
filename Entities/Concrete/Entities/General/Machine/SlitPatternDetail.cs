using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class SlitPatternDetail:IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilSlitPatternId { get; set; }
        public string? MainCoilProductionId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? MinimumOuterDiameter { get; set; }
        public decimal? MaximumOuterDiameter { get; set; }
        public decimal? MinimumWidth { get; set; }
        public decimal? MaximumWidth { get; set; }
        public decimal? MinimumThickness { get; set; }
        public decimal? MaximumThickness { get; set; }
        public decimal? TargetLength { get; set; }
        public decimal? MinimumLength { get; set; }
        public decimal? MaximumLength { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

