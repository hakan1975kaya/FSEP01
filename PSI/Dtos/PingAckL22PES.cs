﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos
{
    public class PingAckL22PES : IDto
    {
        public TypeHeader Header { get; set; }
        public string TelegramSeqNo { get; set; }
    }
}





