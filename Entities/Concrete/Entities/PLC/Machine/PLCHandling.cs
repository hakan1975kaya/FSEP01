using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Machine
{
    public class PLCHandling : IEntity
    {
        public Guid Id { get; set; }
        public Guid PLCGeneralId { get; set; }
        public decimal? PositionHandling { get; set; }//Name:Pos_Handling,Adress:DB 233 DBD 44,Data Type:DInt
        public decimal? PositionHandlingLiftOne { get; set; }//Name:Pos_Handling_Lift_1,Adress:DB 230 DBD 44,Data Type:DInt
        public decimal? PositionHandlingLiftTwo { get; set; }//Name:Pos_Handling_Lift_2,Adress:DB 231 DBD 44,Data Type:DInt
        public long? HandlingPositionOne { get; set; }//Name:Handling_Set_Pos1,Adress:DB 233 DBD 68,Data Type:Real
        public long? HandlingPositionTwo { get; set; }//Name:Handling_Set_Pos2,Adress:DB 233 DBD 72,Data Type:Real
        public long? HandlingPositionThree { get; set; }//Name:Handling_Set_Pos3,Adress:DB 233 DBD 76,Data Type:Real
        public long? HandlingPositionFour { get; set; }//Name:Handling_Set_Pos4,Adress:DB 233 DBD 80,Data Type:Real
        public long? HandlingPositionFive { get; set; }//Name:Handling_Set_Pos1,Adress:DB 233 DBD 84,Data Type:Real
        public bool? LiftOnePositionOne { get; set; }//Name:Lift1_Pos1,Adress:M 256.0,Data Type:Bool
        public bool? LiftOnePositionTwo { get; set; }//Name:Lift1_Pos2,Adress:M 256.1,Data Type:Bool
        public bool? LiftOnePositionThree { get; set; }//Name:Lift1_Pos3,Adress:M 256.2,Data Type:Bool
        public bool? LiftOnePositionFour { get; set; }//Name:Lift1_Pos4,Adress:M 256.3,Data Type:Bool
        public bool? LiftOnePositionFive { get; set; }//Name:Lift1_Pos5,Adress:M 256.4,Data Type:Bool
        public bool? LiftOnePositionSix { get; set; }//Name:Lift1_Pos6,Adress:M 256.5,Data Type:Bool
        public bool? LiftOnePositionSeven { get; set; }//Name:Lift1_Pos7,Adress:M 256.6,Data Type:Bool
        public bool? LiftOnePositionEight { get; set; }//Name:Lift1_Pos8,Adress:M 256.7,Data Type:Bool
        public bool? LiftTwoPositionOne { get; set; }//Name:Lift2_Pos1,Adress:M 266.0,Data Type:Bool
        public bool? LiftTwoPositionTwo { get; set; }//Name:Lift2_Pos2,Adress:M 266.1,Data Type:Bool
        public bool? LiftTwoPositionThree { get; set; }//Name:Lift2_Pos3,Adress:M 266.2,Data Type:Bool
        public bool? LiftTwoPositionFour { get; set; }//Name:Lift2_Pos4,Adress:M 266.3,Data Type:Bool
        public bool? LiftTwoPositionFive { get; set; }//Name:Lift2_Pos5,Adress:M 266.4,Data Type:Bool
        public bool? LiftTwoPositionSix { get; set; }//Name:Lift2_Pos6,Adress:M 266.5,Data Type:Bool
        public bool? LiftTwoPositionSeven { get; set; }//Name:Lift2_Pos7,Adress:M 266.6,Data Type:Bool
        public bool? LiftTwoPositionEight { get; set; }//Name:Lift2_Pos8,Adress:M 266.7,Data Type:Bool
        public long? LiftOneSetPositionOne { get; set; }//Name:Lift1_Set_Pos1,Adress:DB 230 DBD 68,Data Type:Real
        public long? LiftOneSetPositionTwo { get; set; }//Name:Lift1_Set_Pos2,Adress:DB 230 DBD 72,Data Type:Real
        public long? LiftOneSetPositionThree { get; set; }//Name:Lift1_Set_Pos3,Adress:DB 230 DBD 76,Data Type:Real
        public long? LiftOneSetPositionFour { get; set; }//Name:Lift1_Set_Pos4,Adress:DB 230 DBD 80,Data Type:Real
        public long? LiftOneSetPositionFive { get; set; }//Name:Lift1_Set_Pos5,Adress:DB 230 DBD 84,Data Type:Real
        public long? LiftOneSetPositionSix { get; set; }//Name:Lift1_Set_Pos6,Adress:DB 230 DBD 88,Data Type:Real
        public long? LiftOneSetPositionSeven { get; set; }//Name:Lift1_Set_Pos7,Adress:DB 230 DBD 92,Data Type:Real
        public long? LiftOneSetPositionEight { get; set; }//Name:Lift1_Set_Pos8,Adress:DB 230 DBD 96,Data Type:Real
        public long? LiftTwoSetPositionOne { get; set; }//Name:Lift2_Set_Pos1,Adress:DB 231 DBD 68,Data Type:Real
        public long? LiftTwoSetPositionTwo { get; set; }//Name:Lift2_Set_Pos2,Adress:DB 231 DBD 72,Data Type:Real
        public long? LiftTwoSetPositionThree { get; set; }//Name:Lift2_Set_Pos3,Adress:DB 231 DBD 76,Data Type:Real
        public long? LiftTwoSetPositionFour { get; set; }//Name:Lift2_Set_Pos4,Adress:DB 231 DBD 80,Data Type:Real
        public long? LiftTwoSetPositionFive { get; set; }//Name:Lift2_Set_Pos5,Adress:DB 231 DBD 84,Data Type:Real
        public long? LiftTwoSetPositionSix { get; set; }//Name:Lift2_Set_Pos6,Adress:DB 231 DBD 88,Data Type:Real
        public long? LiftTwoSetPositionSeven { get; set; }//Name:Lift2_Set_Pos7,Adress:DB 231 DBD 92,Data Type:Real
        public long? LiftTwoSetPositionEight { get; set; }//Name:Lift2_Set_Pos8,Adress:DB 231 DBD 96,Data Type:Real
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

