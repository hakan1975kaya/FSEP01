using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.PLC.Recipe
{
    public class PLCRecipe : IEntity
    {
        public Guid Id { get; set; }
        public int RecipeNumber { get; set; }//TagName:RecipeNumber,TagValue:DB 96 DBW 40
        public int RecipeRecordNumber { get; set; }//TagName:RecipeNumber,TagValue:DB 96 DBW 42
        public int MaterialThickness { get; set; }//Name:Recipe_entry_0_0,DisplayName: Material thickness [µm],TagName:MaterialThickness,TagValue:DB 91 DBW 36
        public int RewinderOneMaterialWidth { get; set; }//Name:Recipe_entry_0_1 ,DisplayName:Material width rewinder [mm] ,TagName:Rew1MaterialWidth,TagValue: DB 91 DBW 310
        public int MachineSpeedSet { get; set; }//Name:Recipe_entry_0_2 ,DisplayName: Set speed [m/min] ,TagName:MachineSpeedSet,TagValue: DB 91 DBW 2
        public int UnwinderOneDiameterSet { get; set; }//Name:Recipe_entry_0_3 ,DisplayName:  Set diameter unwinder [mm] ,TagName:Unw1DiaSet,TagValue: DB 91 DBW 100
        public int RewinderOneDiameterSet { get; set; }//Name:Recipe_entry_0_4 ,DisplayName: Set diameter rewinder 1 [mm],TagName:Rew1DiaSet,TagValue:  DB 91 DBW 300
        public long RewinderOneLengthSet { get; set; }//Name:Recipe_entry_0_5 ,DisplayName: Set length rewinder 1  [m] Set diameter rewinder 1 [mm] ,TagName:Rew1LengthSet,TagValue:  DB 91 DBD 306
        public int RewinderOneTensionSetScaled { get; set; }//Name:Recipe_entry_0_6 ,DisplayName:  Tension rewinder 1 [N/mm²] ,TagName:Rew1TensionSetScaled,TagValue:  DB 91 DBW 312
        public int RewinderOneTensionContactSetScaled { get; set; }//Name:Recipe_entry_0_7 ,DisplayName: Tension contact roll rewinder 1  [N/mm²],TagName:Rew1TensionContSetScaled,TagValue:  DB 91 DBW 342
        public int RewinderTensionLaySetScaled { get; set; }//Name:Recipe_entry_0_8  ,DisplayName:Tension layon roll rewinder 1 [N/mm²],TagName:Rew1TensionLaySetScaled,TagValue:  DB 91 DBW 372
        public int RewinderOnePressureContactBalance { get; set; }//Name:Recipe_entry_0_10  ,DisplayName: Balance contact roll rewinder 1 [%],TagName:Rew1PresContBalance,TagValue:  DB 91 DBW 336
        public int RewinderOnePressureLaySetScaled { get; set; }//Name:Recipe_entry_0_11  ,DisplayName:  Pressure layon roll rewinder 1 [N/mm],TagName:Rew1PresLaySetScaled,TagValue:  DB 91 DBW 352
        public int RewinderOnePresLayBalance { get; set; }//Name:Recipe_entry_0_12  ,DisplayName: Balance layon roll rewinder 1 [%],TagName:Rew1PresLayBalance,TagValue: DB 91 DBW 366
        public int RewinderTwoDiameterSet { get; set; }//Name:Recipe_entry_0_13  ,DisplayName: Set diameter rewinder 2  [mm],TagName:Rew2DiaSet,TagValue:  DB 91 DBW 400
        public long RewinderTwoLengthSet { get; set; }//Name:Recipe_entry_0_14  ,DisplayName: Set length rewinder 2 [m],TagName:Rew2LengthSet,TagValue: DB 91 DBD 406
        public int RewinderTwoTensionSetScaled { get; set; }//Name:Recipe_entry_0_15  ,DisplayName: Tension rewinder 2 [N/mm²],TagName:Rew2TensionSetScaled,TagValue:  DB 91 DBW 412
        public int RewinderTwoTensionContactSetScaled { get; set; }//Name:Recipe_entry_0_16  ,DisplayName:  Tension contact roll rewinder 2  [N/mm²],TagName:Rew2TensionContSetScaled,TagValue:   DB 91 DBW 442
        public int RewinderTwoTensionSupportSetScaled { get; set; }//Name:Recipe_entry_0_17  ,DisplayName: Tension support roll rewinder 2  [N/mm²],TagName:Rew2TensionSupSetScaled,TagValue:  DB 91 DBW 472
        public int RewinderTwoPressureContactSetScaled { get; set; }//Name:Recipe_entry_0_18  ,DisplayName: Pressure contact roll rewinder 2  [N/mm],TagName:Rew2PresContSetScaled,TagValue:  DB 91 DBW 422
        public int RewinderTwoPressureContactBalance { get; set; }//Name:Recipe_entry_0_19  ,DisplayName: Balance pres. cont. roll rew. 2[%],TagName:Rew2PresContBalance,TagValue:  DB 91 DBW 436
        public int RewinderTwoPressureSupportSetScaled { get; set; }//Name:Recipe_entry_0_20  ,DisplayName: Pressure support roll rewinder 2  [N/mm],TagName:Rew2PresSupSetScaled,TagValue:DB 91 DBW 452
        public int RewinderTwoPressureSupportBalance { get; set; }//Name:Recipe_entry_0_21  ,DisplayName:Balance pres. sup. roll rew. 2 [%] ,TagName:Rew2PresSupBalance,TagValue: DB 91 DBW 466
        public int MachineTimeAcceleration { get; set; }//Name:Recipe_entry_0_22  ,DisplayName: Acceleration time [s],TagName:MachineTimeAccel,TagValue:DB 91 DBW 8
        public int MachineTimeDecelarition { get; set; }//Name:Recipe_entry_0_23  ,DisplayName:Deceleration time [s] ,TagName:MachineTimeDecel,TagValue:DB 91 DBW 10
        public int MachineTimeFastStop { get; set; }//Name:Recipe_entry_0_24  ,DisplayName: Fast stop time [s] ,TagName:MachineTimeFastStop,TagValue:  DB 91 DBW 12
        public int TransportTensionSet { get; set; }//Name:Recipe_entry_0_25  ,DisplayName: Set tension transport rolls [%] ,TagName:TransportTensionSet,TagValue:  DB 91 DBW 550
        public int MachineWeldingSpeedSet { get; set; }//Name:Recipe_entry_0_26   ,DisplayName:Welding speed [mm/s],TagName:MachineWeldingSpeedSet,TagValue:  DB 91 DBW 80
        public int RewinderOneCharacteristicTensionOne { get; set; }//Name:Recipe_entry_0_27  ,DisplayName:Tension characteristic rew.1 [di][%] ,TagName:Rew1CharacteristicTension_D01,TagValue: DB 93 DBW 2
        public int RewinderOneCharacteristicTensionTwo { get; set; }//Name:Recipe_entry_0_28  ,DisplayName:Tension characteristic rew.1 [d2][%],TagName:Rew1CharacteristicTension_D02,TagValue:  DB 93 DBW 4
        public int RewinderOneCharacteristicTensionThree { get; set; }//Name:Recipe_entry_0_29  ,DisplayName:Tension characteristic rew.1 [d3][%],TagName:Rew1CharacteristicTension_D03,TagValue:  DB 93 DBW 6
        public int RewinderOneCharacteristicTensionFour { get; set; }//Name:Recipe_entry_0_30  ,DisplayName:Tension characteristic rew.1 [d4][%],TagName:Rew1CharacteristicTension_D04,TagValue:  DB 93 DBW 8
        public int RewinderOneCharacteristicTensionFive { get; set; }//Name:Recipe_entry_0_31  ,DisplayName:Tension characteristic rew.1 [d5][%],TagName:Rew1CharacteristicTension_D05,TagValue:  DB 93 DBW 10
        public int RewinderOneCharacteristicTensionSix { get; set; }//Name:Recipe_entry_0_32 ,DisplayName:Tension characteristic rew.1 [d6][%],TagName:Rew1CharacteristicTension_D06,TagValue:  DB 93 DBW 12
        public int RewinderOneCharacteristicTensionSeven { get; set; }//Name:Recipe_entry_0_33  ,DisplayName:Tension characteristic rew.1 [d7][%],TagName:Rew1CharacteristicTension_D07,TagValue:  DB 93 DBW 14
        public int RewinderOneCharacteristicTensionEight { get; set; }//Name:Recipe_entry_0_34  ,DisplayName:Tension characteristic rew.1 [d8][%],TagName:Rew1CharacteristicTension_D08,TagValue:  DB 93 DBW 16
        public int RewinderOneCharacteristicTensionNine { get; set; }//Name:Recipe_entry_0_35 ,DisplayName:Tension characteristic rew.1 [d9][%],TagName:Rew1CharacteristicTension_D09,TagValue:  DB 93 DBW 18
        public int RewinderOneCharacteristicTensionTen { get; set; }//Name:Recipe_entry_0_36 ,DisplayName:Tension characteristic rew.1 [d10][%],TagName:Rew1CharacteristicTension_D010,TagValue:  DB 93 DBW 20
        public int RewinderOneCharacteristicTensionSpeedInfluence { get; set; }//Name:Recipe_entry_0_37 ,DisplayName:Tension characteristic rew.1 speed   [%],TagName:Rew1CharacteristicTensionSpeedInfluence,TagValue:    DB 93 DBW 0
        public int RewinderOneCharacteristicPressureContactOne { get; set; }//Name:Recipe_entry_0_38 ,DisplayName: Pressure char. cont. roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureContact_D01,TagValue: DB 93 DBW 122
        public int RewinderOneCharacteristicPressureContactTwo { get; set; }//Name:Recipe_entry_0_39 ,DisplayName: Pressure char. cont. roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureContact_D02,TagValue: DB 93 DBW 124
        public int RewinderOneCharacteristicPressureContactThree { get; set; }//Name:Recipe_entry_0_40 ,DisplayName: Pressure char. cont. roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureContact_D03,TagValue: DB 93 DBW 126
        public int RewinderOneCharacteristicPressureContactFour { get; set; }//Name:Recipe_entry_0_41 ,DisplayName: Pressure char. cont. roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 128
        public int RewinderOneCharacteristicPressureContactFive { get; set; }//Name:Recipe_entry_0_42 ,DisplayName: Pressure char. cont. roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 130
        public int RewinderOneCharacteristicPressureContactSix { get; set; }//Name:Recipe_entry_0_43 ,DisplayName: Pressure char. cont. roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureContact_D06,TagValue: DB 93 DBW 132
        public int RewinderOneCharacteristicPressureContactSeven { get; set; }//Name:Recipe_entry_0_44 ,DisplayName: Pressure char. cont. roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureContact_D07,TagValue: DB 93 DBW 134
        public int RewinderOneCharacteristicPressureContactEight { get; set; }//Name:Recipe_entry_0_45 ,DisplayName: Pressure char. cont. roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureContact_D08,TagValue: DB 93 DBW 136
        public int RewinderOneCharacteristicPressureContactNine { get; set; }//Name:Recipe_entry_0_46 ,DisplayName: Pressure char. cont. roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureContact_D09,TagValue: DB 93 DBW 138
        public int RewinderOneCharacteristicPressureContactTen { get; set; }//Name:Recipe_entry_0_47 ,DisplayName: Pressure char. cont. roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureContact_D10,TagValue: DB 93 DBW 140
        public int RewinderOneCharacteristicPressureContactSpeedInfluence { get; set; }//Name:Recipe_entry_0_48 ,DisplayName:Pressure char. cont. roll rew.1 speed[%],TagName:Rew1CharacteristicPressureContactSpeedInfluence,TagValue:    DB 93 DBW 120
        public int RewinderOneCharacteristicPressureLayOnOne { get; set; }//Name:Recipe_entry_0_49 ,DisplayName:Pressure char. layon roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureLayOn_D01,TagValue:   DB 93 DBW 182
        public int RewinderOneCharacteristicPressureLayOnTwo { get; set; }//Name:Recipe_entry_0_50 ,DisplayName:Pressure char. layon roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureLayOn_D02,TagValue:   DB 93 DBW 184
        public int RewinderOneCharacteristicPressureLayOnThree { get; set; }//Name:Recipe_entry_0_51 ,DisplayName:Pressure char. layon roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureLayOn_D03,TagValue:   DB 93 DBW 186
        public int RewinderOneCharacteristicPressureLayOnFour { get; set; }//Name:Recipe_entry_0_52 ,DisplayName:Pressure char. layon roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureLayOn_D04,TagValue:   DB 93 DBW 188
        public int RewinderOneCharacteristicPressureLayOnFive { get; set; }//Name:Recipe_entry_0_53 ,DisplayName:Pressure char. layon roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureLayOn_D05,TagValue:   DB 93 DBW 190
        public int RewinderOneCharacteristicPressureLayOnSix { get; set; }//Name:Recipe_entry_0_54 ,DisplayName:Pressure char. layon roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureLayOn_D06,TagValue:   DB 93 DBW 192
        public int RewinderOneCharacteristicPressureLayOnSeven { get; set; }//Name:Recipe_entry_0_55 ,DisplayName:Pressure char. layon roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureLayOn_D07,TagValue:   DB 93 DBW 194
        public int RewinderOneCharacteristicPressureLayOnEight { get; set; }//Name:Recipe_entry_0_56 ,DisplayName:Pressure char. layon roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureLayOn_D08,TagValue:   DB 93 DBW 196
        public int RewinderOneCharacteristicPressureLayOnNine { get; set; }//Name:Recipe_entry_0_57 ,DisplayName:Pressure char. layon roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureLayOn_D09,TagValue:   DB 93 DBW 198
        public int RewinderOneCharacteristicPressureLayOnTen { get; set; }//Name:Recipe_entry_0_58 ,DisplayName:Pressure char. layon roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureLayOn_D010,TagValue:   DB 93 DBW 200
        public int RewinderOneCharacteristicPressureLayOnSpeedInfluence { get; set; }//Name:Recipe_entry_0_59 ,DisplayName: Pressure char. layon roll rew.1 speed[%],TagName:Rew1CharacteristicPressureLayOnSpeedInfluence,TagValue:  DB 93 DBW 180
        public int RewinderTwoCharacteristicTensionOne { get; set; }//Name:Recipe_entry_0_60 ,DisplayName:Tension characteristic rew.2 [d1][%],TagName:Rew2CharacteristicTension_D01,TagValue:   DB 93 DBW 32
        public int RewinderTwoCharacteristicTensionTwo { get; set; }//Name:Recipe_entry_0_61 ,DisplayName:Tension characteristic rew.2 [d2][%],TagName:Rew2CharacteristicTension_D02,TagValue:   DB 93 DBW 34
        public int RewinderTwoCharacteristicTensionThree { get; set; }//Name:Recipe_entry_0_62 ,DisplayName:Tension characteristic rew.2 [d3][%],TagName:Rew2CharacteristicTension_D03,TagValue:   DB 93 DBW 36
        public int RewinderTwoCharacteristicTensionFour { get; set; }//Name:Recipe_entry_0_63 ,DisplayName:Tension characteristic rew.2 [d4][%],TagName:Rew2CharacteristicTension_D04,TagValue:   DB 93 DBW 38
        public int RewinderTwoCharacteristicTensionFive { get; set; }//Name:Recipe_entry_0_64 ,DisplayName:Tension characteristic rew.2 [d5][%],TagName:Rew2CharacteristicTension_D05,TagValue:   DB 93 DBW 40
        public int RewinderTwoCharacteristicTensionSix { get; set; }//Name:Recipe_entry_0_65 ,DisplayName:Tension characteristic rew.2 [d6][%],TagName:Rew2CharacteristicTension_D06,TagValue:   DB 93 DBW 42
        public int RewinderTwoCharacteristicTensionSeven { get; set; }//Name:Recipe_entry_0_66 ,DisplayName:Tension characteristic rew.2 [d7][%],TagName:Rew2CharacteristicTension_D07,TagValue:   DB 93 DBW 44
        public int RewinderTwoCharacteristicTensionEight { get; set; }//Name:Recipe_entry_0_67 ,DisplayName:Tension characteristic rew.2 [d8][%],TagName:Rew2CharacteristicTension_D08,TagValue:   DB 93 DBW 46
        public int RewinderTwoCharacteristicTensionNine { get; set; }//Name:Recipe_entry_0_68 ,DisplayName:Tension characteristic rew.2 [d9][%],TagName:Rew2CharacteristicTension_D09,TagValue:   DB 93 DBW 48
        public int RewinderTwoCharacteristicTensionTen { get; set; }//Name:Recipe_entry_0_69 ,DisplayName:Tension characteristic rew.2 [d10][%],TagName:Rew2CharacteristicTension_D010,TagValue:   DB 93 DBW 50
        public int RewinderTwoCharacteristicTensionSpeedInfluence { get; set; }//Name:Recipe_entry_0_70 ,DisplayName:Tension characteristic rew.2 speed[%],TagName:Rew2CharacteristicTensionSpeedInfluence,TagValue: DB 93 DBW 30
        public int RewinderTwoCharacteristicPressureContactOne { get; set; }//Name:Recipe_entry_0_71 ,DisplayName:Pressure char. cont. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureContact_D01,TagValue:  DB 93 DBW 152
        public int RewinderTwoCharacteristicPressureContactTwo { get; set; }//Name:Recipe_entry_0_72 ,DisplayName:Pressure char. cont. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureContact_D02,TagValue:  DB 93 DBW 154
        public int RewinderTwoCharacteristicPressureContactThree { get; set; }//Name:Recipe_entry_0_73 ,DisplayName:Pressure char. cont. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureContact_D03,TagValue:  DB 93 DBW 156
        public int RewinderTwoCharacteristicPressureContactFour { get; set; }//Name:Recipe_entry_0_74 ,DisplayName:Pressure char. cont. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureContact_D04,TagValue:  DB 93 DBW 158
        public int RewinderTwoCharacteristicPressureContactFive { get; set; }//Name:Recipe_entry_0_75 ,DisplayName:Pressure char. cont. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureContact_D05,TagValue:  DB 93 DBW 160
        public int RewinderTwoCharacteristicPressureContactSix { get; set; }//Name:Recipe_entry_0_76 ,DisplayName:Pressure char. cont. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureContact_D06,TagValue:  DB 93 DBW 162
        public int RewinderTwoCharacteristicPressureContactSeven { get; set; }//Name:Recipe_entry_0_77 ,DisplayName:Pressure char. cont. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureContact_D07,TagValue:  DB 93 DBW 164
        public int RewinderTwoCharacteristicPressureContactEight { get; set; }//Name:Recipe_entry_0_78 ,DisplayName:Pressure char. cont. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureContact_D08,TagValue:  DB 93 DBW 166
        public int RewinderTwoCharacteristicPressureContactNine { get; set; }//Name:Recipe_entry_0_79 ,DisplayName:Pressure char. cont. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureContact_D09,TagValue:  DB 93 DBW 168
        public int RewinderTwoCharacteristicPressureContactTen { get; set; }//Name:Recipe_entry_0_80 ,DisplayName:Pressure char. cont. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureContact_D010,TagValue:  DB 93 DBW 170
        public int RewinderTwoCharacteristicPressureContactSpeedInfluence { get; set; }//Name:Recipe_entry_0_81 ,DisplayName: Pressure char. cont. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureContactSpeedInfluence,TagValue: DB 93 DBW 150
        public int RewinderTwoCharacteristicPressureSupportOne { get; set; }//Name:Recipe_entry_0_82 ,DisplayName:Pressure char. supp. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureSupport_D01,TagValue:DB 93 DBW 212
        public int RewinderTwoCharacteristicPressureSupportTwo { get; set; }//Name:Recipe_entry_0_83 ,DisplayName:Pressure char. supp. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureSupport_D02,TagValue:DB 93 DBW 214
        public int RewinderTwoCharacteristicPressureSupportThree { get; set; }//Name:Recipe_entry_0_84 ,DisplayName:Pressure char. supp. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureSupport_D03,TagValue:DB 93 DBW 216
        public int RewinderTwoCharacteristicPressureSupportFour { get; set; }//Name:Recipe_entry_0_85 ,DisplayName:Pressure char. supp. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureSupport_D04,TagValue:DB 93 DBW 218
        public int RewinderTwoCharacteristicPressureSupportFive { get; set; }//Name:Recipe_entry_0_86 ,DisplayName:Pressure char. supp. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureSupport_D05,TagValue:DB 93 DBW 220
        public int RewinderTwoCharacteristicPressureSupportSix { get; set; }//Name:Recipe_entry_0_87 ,DisplayName:Pressure char. supp. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureSupport_D06,TagValue:DB 93 DBW 222
        public int RewinderTwoCharacteristicPressureSupportSeven { get; set; }//Name:Recipe_entry_0_88 ,DisplayName:Pressure char. supp. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureSupport_D07,TagValue:DB 93 DBW 224
        public int RewinderTwoCharacteristicPressureSupportEight { get; set; }//Name:Recipe_entry_0_89 ,DisplayName:Pressure char. supp. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureSupport_D08,TagValue:DB 93 DBW 226
        public int RewinderTwoCharacteristicPressureSupportNine { get; set; }//Name:Recipe_entry_0_90 ,DisplayName:Pressure char. supp. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureSupport_D09,TagValue:DB 93 DBW 228
        public int RewinderTwoCharacteristicPressureSupportTen { get; set; }//Name:Recipe_entry_0_91 ,DisplayName:Pressure char. supp. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureSupport_D010,TagValue:DB 93 DBW 230
        public int RewinderTwoCharacteristicPressureSupportSpeedInfluence { get; set; }//Name:Recipe_entry_0_92 ,DisplayName: Pressure char. supp. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureSupportSpeedInfluence,TagValue:  DB 93 DBW 210
    }
}

