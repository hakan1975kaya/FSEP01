using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCMachine:IEntity
    {
        public Guid Id { get; set; }
        public long? MachineSpeedSet { get; set; }//Name:MachineSpeedSet,Adress:DB 91 DBW 2,Data Type:Int
        public long? TransportOneTensionSet { get; set; }//Name:Transport1TensionSet,Adress:DB 91 DBW 550,Data Type:Int
        public long? TransportTwoTensionSet { get; set; }//Name:Transport2TensionSet,Adress:DB 91 DBW 560,Data Type:Int
        public long? WeightRewinderOne { get; set; }//Name:Weight_Rew_1,Adress:DB 1 DBD 2384,Data Type:Int
        public long? WeightRewinderTwo { get; set; }//Name:Weight_Rew_2,Adress:DB 1 DBD 2380,Data Type:Int
        public long? RewinderOneDiameterSet { get; set; }//Name:Rew1DiaSet,Adress:DB 91 DBW 300,Data Type:Int
        public long? RewinderOneDiameterActuel { get; set; }//Name:Rew1DiaAct,Adress:DB 90 DBW 300,Data Type:Int
        public long? RewinderOneLengthSet { get; set; }//Name:Rew1LengthSet,Adress:DB 91 DBD 306,Data Type:Int
        public long? RewinderOneLengthActue { get; set; }//Name:Rew1LengthAct,Adress:DB 90 DBD 306,Data Type:Int
        public long? RewinderTwoDiameterSet { get; set; }//Name:Rew2DiaSet,Adress:DB 91 DBW 400,Data Type:Int
        public long? RewinderTwoDiameterActuel { get; set; }//Name:Rew2DiaAct,Adress:DB 90 DBW 400,Data Type:Int
        public long? RewinderTwoLengthSet { get; set; }//Name:Rew2LengthSet,Adress:DB 91 DBD 406,Data Type:Int
        public long? RewinderTwoLengthActuel { get; set; }//Name:Rew2LengthAct,Adress:DB 90 DBD 406,Data Type:Int
        public long? UnwinderOneDiameterSet { get; set; }//Name:Unw1DiaSet,Adress:DB 91 DBW 100,Data Type:Int
        public long? UnwinderOneDiameterActuel { get; set; }//Name:Unw1DiaAct,Adress:DB 90 DBW 100,Data Type:Int
        public bool? RewinderOneResetLength { get; set; }//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.2
        public bool? RewinderTwoResetLength { get; set; }//Name:MachineFunctFlag1,Adress:DB 91 DBW 28,Data Type:Int,ResetLength:91.28.3
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }

    }
}
