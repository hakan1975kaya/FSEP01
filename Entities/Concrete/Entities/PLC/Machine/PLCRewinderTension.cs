using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCRewinderTension:IEntity
    {
        public Guid Id { get; set; }
        public Guid PLCGeneralId { get; set; }
        public decimal? RewinderOneTensionSetScaled { get; set; }//Name:Rew1TensionSetScaled,Adress:DB 91 DBW 312,Data Type:Int
        public decimal? RewinderOneTensionCalculateCharScaled { get; set; }//Name:Rew1TensionCalcCharScaled,Adress:DB 90 DBW 316,Data Type:Int
        public decimal? RewinderOneTensionActuelMeasureScaled { get; set; }//Name:Rew1TensionActMeasScaled,Adress:DB 90 DBW 312,Data Type:Int
        public decimal? RewinderOneTensionCalculateCharNewton { get; set; }//Name:Rew1TensionCalcCharNewton,Adress:DB 90 DBW 318,Data Type:Int
        public decimal? RewinderOneTensionActuelMeasureNewton { get; set; }//Name:Rew1TensionActMeasNewton,AdressDB 90 DBW 314,Data Type:Int
        public decimal?  RewinderOneTensionContactSetScaled { get; set; }//Name:Rew1TensionContSetScaled,Adress:DB DB 91 DBW 342,Data Type:Int
        public short? RewinderOneMaterialWidth { get; set; }//Name:Rew1MaterialWidth,Adress:DB 91 DBW 310,Data Type:Int
        public short? RewinderOneShaft { get; set; }//Name:Rew1Shaft,Adress:DB 91 DBW 382,Data Type:Int
        public decimal? RewinderTwoTensionContactSetScaled { get; set; }//Name:Rew2TensionContSetScaled,Adress:DB 91 DBW 442,Data Type:Int
        public decimal? RewinderTwoTensionSetScaled { get; set; }//Name:Rew2TensionSetScaled,Adress:DB 91 DBW 412,Data Type:Int
        public decimal? RewinderTwoTensionCalculeteCharScaled { get; set; }//Name:Rew2TensionCalcCharScaled,Adress:DB 90 DBW 416,Data Type:Int
        public decimal? RewinderTwoTensionActuelMeasureScaled { get; set; }//Name:Rew2TensionActMeasScaled,Adress:DB 90 DBW 412,Data Type:Int
        public short?  RewinderTwoTensionCalculateCharNewton { get; set; }//Name:Rew2TensionCalcCharNewton,Adress:DB 90 DBW 418,Data Type:Int
        public short? RewinderTwoTensionActuelMeasureNewton { get; set; }//Name:Rew2TensionActMeasNewton,Adress:DB 90 DBW 414,Data Type:Int
        public short? RewinderTwoMaterialWidth { get; set; }//Name:Rew2MaterialWidth,Adress:DB 91 DBW 410,Data Type:Int
        public short? RewinderTwoShaft { get; set; }//Name:Rew2Shaft,Adress:DB 91 DBW 482,Data Type:Int
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}


