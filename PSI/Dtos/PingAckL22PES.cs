﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class PingAckL22PES:IDto
    {
        public Guid Id { get; set; }
        public TypeHeader Header { get; set; }
        public string TelegramSeqNo { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}





