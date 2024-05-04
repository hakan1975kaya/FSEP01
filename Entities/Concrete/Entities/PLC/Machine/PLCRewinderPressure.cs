using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCRewinderPressure:IEntity
    {
        public Guid Id { get; set; }
        public Guid PLCGeneralId { get; set; }
        public decimal? RewinderOnePressureLaySetScaled { get; set; }//Name:Rew1PresLaySetScaled,Adress:DB 91 DBW 352,Data Type:Int
        public decimal? RewinderOnePressureLayCalculateCharScaled { get; set; }//Name:Rew1PresLayCalcCharScaled,Adress:DB 90 DBW 356,Data Type:Int
        public int? RewinderOnePresureLayBalance { get; set; }//Name:Rew1PresLayBalance,Adress:DB 91 DBW 366,Data Type:Int
        public decimal? RewinderOnePressureLayCalculateRight { get; set; }//Name:Rew1PresLayCalcRight,Adress:DB 90 DBW 364,Data Type:Int
        public decimal? RewinderOnePressureLayCalculateLeft { get; set; }//Name:Rew1PresLayCalcLeft,Adress:DB 90 DBW 362,Data Type:Int
        public decimal? RewinderOnePressureContactSetScaled { get; set; }//Name:Rew1PresContSetScaled,Adress:DB 91 DBW 322,Data Type:Int
        public decimal? RewinderOnePressureContactCalculateCharScaled { get; set; }//Name:Rew1PresContCalcCharScaled,Adress:DB 90 DBW 326,Data Type:Int     
        public int? RewinderOnePressureContactBalance { get; set; }//Name:Rew1PresContBalance,Adress:DB 91 DBW 336,Data Type:Int
        public decimal? RewinderOnePressureContactCalculateRight { get; set; }//Name:Rew1PresContCalcRight,AdressDB 90 DBW 334,Data Type:Int
        public decimal? RewinderOnePressureContactCalculateLeft { get; set; }//Name:Rew1PresContCalcLeft,Adress:DB 90 DBW 332,Data Type:Int
        public decimal? RewinderTwoPressureContanctSetScaled { get; set; }//Name:Rew2PresContSetScaled,Adress:DB 91 DBW 422,Data Type:Int
        public decimal? RewinderTwoPressureContactCalculateCharScaled { get; set; }//Name:Rew2PresContCalcCharScaled,Adress:DB 90 DBW 426,Data Type:Int       
        public int? RewinderTwoPressureContanctBalance { get; set; }//Name:Rew2PresContBalance,Adress:DB 91 DBW 436,Data Type:Int
        public decimal? RewinderTwoPressureContactCalculateRight { get; set; }//Name:Rew2PresContCalcRight,Adress:DB 90 DBW 434,Data,Type:Int
        public decimal? RewinderTwoPressureContactCalculateLeft { get; set; }//Name:Rew2PresContCalcLeft,Adress:DB 90 DBW 432,Data Type:Int
        public decimal? RewinderTwoPressureSupportSetScaled { get; set; }//Name:Rew2PresSupSetScaled,Adress:DB 91 DBW 452,Data Type:Int
        public decimal? RewinderTwoPressureSupportCalculateCharScaled { get; set; }//Name:Rew2PresSupCalcCharScaled,Adress:DB 90 DBW 456,Data Type:Int
        public int? RewinderTwoPressureSupportBalance { get; set; }//Name:Rew2PresSupBalance,Adress:DB 91 DBW 466,Data Type:Int
        public decimal? RewinderTwoPressureSupportCalcuteRight { get; set; }//Name:Rew2PresSupCalcRight,Adress:DB 90 DBW 464,Data Type:Int
        public decimal? RewinderTwoPressureSupportCalcuteLeft { get; set; }//Name:Rew2PresSupCalcLeft,Adress:DB 90 DBW 462,Data Type:Int
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

