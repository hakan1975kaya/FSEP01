using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCBasicData : IEntity
    {
        public Guid Id { get; set; }
        public decimal? RewinderOneDiameterLayRoll { get; set; }//Name:Rew1DiaLayRoll,Adress:DB 91 DBD 368,Data Type:DInt
        public decimal? RewinderOneDiameterContactRoll { get; set; }//Name:Rew1DiaContRoll,Adress:DB 91 DBD 338,Data Type:Int
        public decimal? RewinderTwoDiameterContactRoll { get; set; }//Name:Rew2DiaContRoll,Adress:DB 91 DBD 438,Data Type:DInt
        public decimal? RewinderTwoDiameterSupportRoll { get; set; }//Name:Rew2DiaSupRoll,Adress:DB 91 DBD 468,Data Type:DInt
        public decimal? MaterialSpecGravity { get; set; }//Name:MaterialSpecGravity,Adress:DB 91 DBW 38,Data Type:Int
        public int? UnwinderOneMaterialWidth { get; set; }//Name:Unw1MaterialWidth,Adress:DB 91 DBW 110,Data Type:Int
        public decimal? MaterialThickness { get; set; }//Name:MaterialThickness,Adress:DB 91 DBW 36,Data Type:Int
        public decimal? MaterialThicknessCalculatedValueActuel { get; set; }//HMI:Only Read,Name:MaterialThicknessCalc,Adress:DB 90 DBW 36,Data Type:Int
        public decimal? MaterialThicknessCalculatedValueMinimum { get; set; }//Name:MaterialThicknessMin,Adress:DB 90 DBW 124,Data Type:Int
        public decimal? MaterialThicknessCalculatedValueMaximum { get; set; }//Name:MaterialThicknessMax,Adress:DB 90 DBW 126,Data Type:Int
        public short? MachineWeldingSpeedSet { get; set; }//Name:MachineWeldingSpeedSet_0,Adress:DB 91 DBW 80,Data Type:Int
        public short? MachineWeldingAmplitudeSet { get; set; }//Name:MachineWeldingAmplitudeSet,Adress:DB 91 DBW 82,Data Type:Int
        public decimal? MachineWeldingPowerActuel { get; set; }//HMI:Read Only, Name:MachineWeldingPowerAct,Adress:DB 90 DBW 82,Data Type:Int
        public short? MachineTimeAcceleration { get; set; }//Name:MachineTimeAccel,Addres:DB 91 DBW 8
        public short? MachineTimeDecelaration { get; set; }//Name:MachineTimeDecel,Addres:DB 91 DBW 10
        public short? MachineTimeFastStop { get; set; }//Name:MachineTimeFastStop,Addres:DB 91 DBW 12
        public short? MachineSpeedJog { get; set; }//Name:MachineSpeedJog,Addres:DB 91 DBW 4
        public long? MachineLengthTotal { get; set; }//Name:MachineLengthTotal,Adress:DB 90 DBD 16,Data Type:DInt
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

