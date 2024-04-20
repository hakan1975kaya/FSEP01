using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class ParameterBasicData:IEntity
    {
        public Guid Id { get; set; }
        public Guid ParameterId { get; set; }
        public short? Acceleration { get; set; }//Hızlanma
        public short? Deceleration { get; set; }//Yavaşlama
        public short? FastStop { get; set; }//Hızlı Durdurma
        public short? JogSpeed { get; set; }//Jog Hızı
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
