using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCMachineOverview : IEntity
    {
        public Guid Id { get; set; }
        public long? UnwinderOneDiameterActuel { get; set; }//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
        public long? TransportOneTensionSet { get; set; }//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
        public long? TransportTwoTensionSet { get; set; }//Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
        public decimal? RewinderOneTensionLaySetScaled { get; set; }//Name:Rew1TensionLaySetScaled,Adress:DB 91 DBW 372,Data Type:Int
        public decimal? RewinderOneTensionCalculateCharScaled { get; set; }//Name:Rew1TensionCalcCharScaled,Adress:DB 90 DBW 316,Data Type:Int
        public long? RewinderOneLengthActuel { get; set; }//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        public long? RewinderOneDiameterActuel { get; set; }//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        public decimal? ContactOneTensionActuel { get; set; }//Name:Cont1TensionAct,Adress:DB 90 DBW 580,Data Type:Int
        public decimal? ContactTwoTensionActuel { get; set; }//Name:Cont2TensionAct,Adress:DB 90 DBW 590,Data Type:Int      
        public decimal? RewinderTwoTensionCalculateCharScaled { get; set; }//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
        public long? RewinderTwoLengthActuel { get; set; }//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
        public long? RewinderTwoDiameterActuel { get; set; }//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        public decimal? RewinderTwoTensionSupportSetScaled { get; set; }//Name:Rew2TensionCalcCharScaled,Adress:DB 91 DBW 472,Data Type:Int
        public decimal? RewinderOnePressureLayCalculateCharScaled { get; set; }//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:Int
        public decimal? RewinderOnePressureContactCalculateCharScaled { get; set; }//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int
        public decimal? RewinderTwoPressureContactCalculateCharScaled { get; set; }//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int
        public decimal? RewinderTwoPressureSupportCalculateCharScaled { get; set; }//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
