﻿using Core.Entities.Abstract;
using Entities.Concrete.Enums.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class WebLog : IEntity
    {
        public Guid Id { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public AuditEnum Audit { get; set; }
    }
}
