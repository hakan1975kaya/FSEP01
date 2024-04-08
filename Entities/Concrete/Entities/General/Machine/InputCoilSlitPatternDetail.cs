using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilSlitPatternDetail : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilSlitPatternId { get; set; }
        public string? POId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? MinOuterDiameter { get; set; }
        public decimal? MaxOuterDiameter { get; set; }
        public decimal? MinWidth { get; set; }
        public decimal? MaxWidth { get; set; }
        public decimal? MinThickness { get; set; }
        public decimal? MaxThickness { get; set; }
        public decimal? TargetLength { get; set; }
        public decimal? MinLength { get; set; }
        public decimal? MaxLength { get; set; }
        public int? Status { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
