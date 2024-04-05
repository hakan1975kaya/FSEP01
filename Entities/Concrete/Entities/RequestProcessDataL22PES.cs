using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities
{
    public class RequestProcessDataL22PES:IEntity
    {
        public Guid Id { get; set; }
        public Guid Header { get; set; }
        public Guid EventTime { get; set; }
        public string LineId { get; set; }
        public string ReqType { get; set; }
        public string ReqCategory { get; set; }
        public string ReqKey { get; set; }
        public Guid MatId { get; set; }
        public string SubLine { get; set; }
        public string EventCode { get; set; }
        public string Remark { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
















