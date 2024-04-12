using Core.Entities.Abstract;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Dtos.Telegrams
{
    public class GeneralAckPES2L2 : IDto
    {
        public TypeHeader Header { get; set; }
        public string AckState { get; set; }
        public string InfoCode { get; set; }
        public string InfoText { get; set; }
        public string TelegramSeqNo { get; set; }
        public decimal CountParameter { get; set; }
        public List<TypeParameterList> ParameterList { get; set; }
    }
}
