﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoilAttachment : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? FileName { get; set; }
        public string? Path { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
