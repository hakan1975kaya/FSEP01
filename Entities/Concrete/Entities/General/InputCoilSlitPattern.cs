using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class InputCoilSlitPattern : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? OutputMatPlanId { get; set; }
        public string? POId { get; set; }
        public string? LocalId { get; set; }
        public string? SpoolType { get; set; }
        public int? NeededRewinderDiameter { get; set; }
        public int? NeededRewinderLength { get; set; }
        public int? Status { get; set; }
        public float? NeededRewinderWeight { get; set; }
        public int? RemainingLength { get; set; }
        public int? RemainingWeight { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

