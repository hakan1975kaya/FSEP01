using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class HeadTailScrap : IEntity//Kafa Kuyruk Hurdası
    {
        public Guid Id { get; set; }
        public short? ScrapValue { get; set; }//Hurda değeri
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
