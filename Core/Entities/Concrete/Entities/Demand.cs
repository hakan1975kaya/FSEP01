using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Demand : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string DemandName { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

