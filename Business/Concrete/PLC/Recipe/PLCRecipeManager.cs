using Business.Abstract.PLC.Machine;
using Business.Constants.Messages.PLC.Recipe;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.Entities.PLC.Recipe;
using PLC.Abstract;
using S7.Net;

namespace Business.Concrete.PLC
{
    public class PLCRecipeManager : IPLCRecipeService
    {
        private IPLCDal _plcDal;
        public PLCRecipeManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }
        public async Task<IDataResult<PLCRecipe>> ReadRecipe()
        {
            var plcRecipe = new PLCRecipe();

            plcRecipe.RecipeNumber = (int)_plcDal.Read(DataType.DataBlock, 96, 40, VarType.Int, 1);//TagName:RecipeNumber,TagValue:DB 96 DBW 40
            plcRecipe.MaterialThickness = (int)_plcDal.Read(DataType.DataBlock, 91, 36, VarType.Int, 1);//Name:Recipe_entry_0_0,DisplayName: Material thickness [µm],TagName:MaterialThickness,TagValue:DB 91 DBW 36
            plcRecipe.RewinderOneMaterialWidth = (int)_plcDal.Read(DataType.DataBlock, 91, 310, VarType.Int, 1);//Name:Recipe_entry_0_1 ,DisplayName:Material width rewinder [mm] ,TagName:Rew1MaterialWidth,TagValue: DB 91 DBW 310
            plcRecipe.MachineSpeedSet = (int)_plcDal.Read(DataType.DataBlock, 91, 2, VarType.Int, 1);//Name:Recipe_entry_0_2 ,DisplayName: Set speed [m/min] ,TagName:MachineSpeedSet,TagValue: DB 91 DBW 2
            plcRecipe.UnwinderOneDiameterSet = (int)_plcDal.Read(DataType.DataBlock, 91, 100, VarType.Int, 1);//Name:Recipe_entry_0_3 ,DisplayName:  Set diameter unwinder [mm] ,TagName:Unw1DiaSet,TagValue: DB 91 DBW 100
            plcRecipe.RewinderOneDiameterSet = (int)_plcDal.Read(DataType.DataBlock, 91, 300, VarType.Int, 1);//Name:Recipe_entry_0_4 ,DisplayName: Set diameter rewinder 1 [mm],TagName:Rew1DiaSet,TagValue:  DB 91 DBW 300
            plcRecipe.RewinderOneLengthSet = (long)_plcDal.Read(DataType.DataBlock, 91, 306, VarType.Int, 1);//Name:Recipe_entry_0_5 ,DisplayName: Set length rewinder 1  [m] Set diameter rewinder 1 [mm] ,TagName:Rew1LengthSet,TagValue:  DB 91 DBD 306
            plcRecipe.RewinderOneTensionSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 312, VarType.Int, 1);//Name:Recipe_entry_0_6 ,DisplayName:  Tension rewinder 1 [N/mm²] ,TagName:Rew1TensionSetScaled,TagValue:  DB 91 DBW 312
            plcRecipe.RewinderOneTensionContactSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 342, VarType.Int, 1);//Name:Recipe_entry_0_7 ,DisplayName: Tension contact roll rewinder 1  [N/mm²],TagName:Rew1TensionContSetScaled,TagValue:  DB 91 DBW 342
            plcRecipe.RewinderOneTensionLaySetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 372, VarType.Int, 1);//Name:Recipe_entry_0_8  ,DisplayName:Tension layon roll rewinder 1 [N/mm²],TagName:Rew1TensionLaySetScaled,TagValue:  DB 91 DBW 372
            plcRecipe.RewinderOnePressureContactBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 336, VarType.Int, 1);//Name:Recipe_entry_0_10  ,DisplayName: Balance contact roll rewinder 1 [%],TagName:Rew1PresContBalance,TagValue:  DB 91 DBW 336
            plcRecipe.RewinderOnePressureLaySetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 352, VarType.Int, 1);//Name:Recipe_entry_0_11  ,DisplayName:  Pressure layon roll rewinder 1 [N/mm],TagName:Rew1PresLaySetScaled,TagValue:  DB 91 DBW 352
            plcRecipe.RewinderOnePressureLayBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 366, VarType.Int, 1);//Name:Recipe_entry_0_12  ,DisplayName: Balance layon roll rewinder 1 [%],TagName:Rew1PresLayBalance,TagValue: DB 91 DBW 366
            plcRecipe.RewinderTwoDiameterSet = (int)_plcDal.Read(DataType.DataBlock, 91, 400, VarType.Int, 1);//Name:Recipe_entry_0_13  ,DisplayName: Set diameter rewinder 2  [mm],TagName:Rew2DiaSet,TagValue:  DB 91 DBW 400
            plcRecipe.RewinderTwoLengthSet = (long)_plcDal.Read(DataType.DataBlock, 91, 406, VarType.Int, 1);//Name:Recipe_entry_0_14  ,DisplayName: Set length rewinder 2 [m],TagName:Rew2LengthSet,TagValue: DB 91 DBD 406
            plcRecipe.RewinderTwoTensionSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 412, VarType.Int, 1);//Name:Recipe_entry_0_15  ,DisplayName: Tension rewinder 2 [N/mm²],TagName:Rew2TensionSetScaled,TagValue:  DB 91 DBW 412
            plcRecipe.RewinderTwoTensionContactSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 442, VarType.Int, 1);//Name:Recipe_entry_0_16  ,DisplayName:  Tension contact roll rewinder 2  [N/mm²],TagName:Rew2TensionContSetScaled,TagValue:   DB 91 DBW 442
            plcRecipe.RewinderTwoTensionSupportSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 472, VarType.Int, 1);//Name:Recipe_entry_0_17  ,DisplayName: Tension support roll rewinder 2  [N/mm²],TagName:Rew2TensionSupSetScaled,TagValue:  DB 91 DBW 472
            plcRecipe.RewinderTwoPressureContactSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 422, VarType.Int, 1);//Name:Recipe_entry_0_18  ,DisplayName: Pressure contact roll rewinder 2  [N/mm],TagName:Rew2PresContSetScaled,TagValue:  DB 91 DBW 422
            plcRecipe.RewinderTwoPressureContactBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 436, VarType.Int, 1);//Name:Recipe_entry_0_19  ,DisplayName: Balance pres. cont. roll rew. 2[%],TagName:Rew2PresContBalance,TagValue:  DB 91 DBW 436
            plcRecipe.RewinderTwoPressureSupportSetScaled = (int)_plcDal.Read(DataType.DataBlock, 91, 452, VarType.Int, 1);//Name:Recipe_entry_0_20  ,DisplayName: Pressure support roll rewinder 2  [N/mm],TagName:Rew2PresSupSetScaled,TagValue:DB 91 DBW 452
            plcRecipe.RewinderTwoPressureSupportBalance = (int)_plcDal.Read(DataType.DataBlock, 91, 466, VarType.Int, 1);//Name:Recipe_entry_0_21  ,DisplayName:Balance pres. sup. roll rew. 2 [%] ,TagName:Rew2PresSupBalance,TagValue: DB 91 DBW 466
            plcRecipe.MachineTimeAcceleration = (int)_plcDal.Read(DataType.DataBlock, 91, 8, VarType.Int, 1);//Name:Recipe_entry_0_22  ,DisplayName: Acceleration time [s],TagName:MachineTimeAccel,TagValue:DB 91 DBW 8
            plcRecipe.MachineTimeDecelarition = (int)_plcDal.Read(DataType.DataBlock, 91, 10, VarType.Int, 1);//Name:Recipe_entry_0_23  ,DisplayName:Deceleration time [s] ,TagName:MachineTimeDecel,TagValue:DB 91 DBW 10
            plcRecipe.MachineTimeFastStop = (int)_plcDal.Read(DataType.DataBlock, 91, 12, VarType.Int, 1);//Name:Recipe_entry_0_24  ,DisplayName: Fast stop time [s] ,TagName:MachineTimeFastStop,TagValue:  DB 91 DBW 12
            plcRecipe.TransportTensionSet = (int)_plcDal.Read(DataType.DataBlock, 91, 550, VarType.Int, 1);//Name:Recipe_entry_0_25  ,DisplayName: Set tension transport rolls [%] ,TagName:TransportTensionSet,TagValue:  DB 91 DBW 550
            plcRecipe.MachineWeldingSpeedSet = (int)_plcDal.Read(DataType.DataBlock, 91, 80, VarType.Int, 1);//Name:Recipe_entry_0_26   ,DisplayName:Welding speed [mm/s],TagName:MachineWeldingSpeedSet,TagValue:  DB 91 DBW 80

            plcRecipe.RewinderOneCharacteristicTensionOne = (int)_plcDal.Read(DataType.DataBlock, 93, 2, VarType.Int, 1);//Name:Recipe_entry_0_27  ,DisplayName:Tension characteristic rew.1 [di][%] ,TagName:Rew1CharacteristicTension_D01,TagValue: DB 93 DBW 2
            plcRecipe.RewinderOneCharacteristicTensionTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 4, VarType.Int, 1);//Name:Recipe_entry_0_28  ,DisplayName:Tension characteristic rew.1 [d2][%],TagName:Rew1CharacteristicTension_D02,TagValue:  DB 93 DBW 4
            plcRecipe.RewinderOneCharacteristicTensionThree = (int)_plcDal.Read(DataType.DataBlock, 93, 6, VarType.Int, 1);//Name:Recipe_entry_0_29  ,DisplayName:Tension characteristic rew.1 [d3][%],TagName:Rew1CharacteristicTension_D03,TagValue:  DB 93 DBW 6
            plcRecipe.RewinderOneCharacteristicTensionFour = (int)_plcDal.Read(DataType.DataBlock, 93, 8, VarType.Int, 1);//Name:Recipe_entry_0_30  ,DisplayName:Tension characteristic rew.1 [d4][%],TagName:Rew1CharacteristicTension_D04,TagValue:  DB 93 DBW 8
            plcRecipe.RewinderOneCharacteristicTensionFive = (int)_plcDal.Read(DataType.DataBlock, 93, 10, VarType.Int, 1);//Name:Recipe_entry_0_31  ,DisplayName:Tension characteristic rew.1 [d5][%],TagName:Rew1CharacteristicTension_D05,TagValue:  DB 93 DBW 10
            plcRecipe.RewinderOneCharacteristicTensionSix = (int)_plcDal.Read(DataType.DataBlock, 93, 12, VarType.Int, 1);//Name:Recipe_entry_0_32 ,DisplayName:Tension characteristic rew.1 [d6][%],TagName:Rew1CharacteristicTension_D06,TagValue:  DB 93 DBW 12
            plcRecipe.RewinderOneCharacteristicTensionSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 14, VarType.Int, 1);//Name:Recipe_entry_0_33  ,DisplayName:Tension characteristic rew.1 [d7][%],TagName:Rew1CharacteristicTension_D07,TagValue:  DB 93 DBW 14
            plcRecipe.RewinderOneCharacteristicTensionEight = (int)_plcDal.Read(DataType.DataBlock, 93, 16, VarType.Int, 1);//Name:Recipe_entry_0_34  ,DisplayName:Tension characteristic rew.1 [d8][%],TagName:Rew1CharacteristicTension_D08,TagValue:  DB 93 DBW 16
            plcRecipe.RewinderOneCharacteristicTensionNine = (int)_plcDal.Read(DataType.DataBlock, 93, 18, VarType.Int, 1);//Name:Recipe_entry_0_35 ,DisplayName:Tension characteristic rew.1 [d9][%],TagName:Rew1CharacteristicTension_D09,TagValue:  DB 93 DBW 18
            plcRecipe.RewinderOneCharacteristicTensionTen = (int)_plcDal.Read(DataType.DataBlock, 93, 20, VarType.Int, 1);//Name:Recipe_entry_0_36 ,DisplayName:Tension characteristic rew.1 [d10][%],TagName:Rew1CharacteristicTension_D010,TagValue:  DB 93 DBW 20

            plcRecipe.RewinderOneCharacteristicTensionSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 0, VarType.Int, 1);//Name:Recipe_entry_0_37 ,DisplayName:Tension characteristic rew.1 speed   [%],TagName:Rew1CharacteristicTensionSpeedInfluence,TagValue:    DB 93 DBW 0

            plcRecipe.RewinderOneCharacteristicPressureContactOne = (int)_plcDal.Read(DataType.DataBlock, 93, 122, VarType.Int, 1);//Name:Recipe_entry_0_38 ,DisplayName: Pressure char. cont. roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureContact_D01,TagValue: DB 93 DBW 122
            plcRecipe.RewinderOneCharacteristicPressureContactTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 124, VarType.Int, 1);//Name:Recipe_entry_0_39 ,DisplayName: Pressure char. cont. roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureContact_D02,TagValue: DB 93 DBW 124
            plcRecipe.RewinderOneCharacteristicPressureContactThree = (int)_plcDal.Read(DataType.DataBlock, 93, 126, VarType.Int, 1);//Name:Recipe_entry_0_40 ,DisplayName: Pressure char. cont. roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureContact_D03,TagValue: DB 93 DBW 126
            plcRecipe.RewinderOneCharacteristicPressureContactFour = (int)_plcDal.Read(DataType.DataBlock, 93, 128, VarType.Int, 1);//Name:Recipe_entry_0_41 ,DisplayName: Pressure char. cont. roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 128
            plcRecipe.RewinderOneCharacteristicPressureContactFive = (int)_plcDal.Read(DataType.DataBlock, 93, 130, VarType.Int, 1);//Name:Recipe_entry_0_42 ,DisplayName: Pressure char. cont. roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 130
            plcRecipe.RewinderOneCharacteristicPressureContactSix = (int)_plcDal.Read(DataType.DataBlock, 93, 132, VarType.Int, 1);//Name:Recipe_entry_0_43 ,DisplayName: Pressure char. cont. roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureContact_D06,TagValue: DB 93 DBW 132
            plcRecipe.RewinderOneCharacteristicPressureContactSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 134, VarType.Int, 1);//Name:Recipe_entry_0_44 ,DisplayName: Pressure char. cont. roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureContact_D07,TagValue: DB 93 DBW 134
            plcRecipe.RewinderOneCharacteristicPressureContactEight = (int)_plcDal.Read(DataType.DataBlock, 93, 136, VarType.Int, 1);//Name:Recipe_entry_0_45 ,DisplayName: Pressure char. cont. roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureContact_D08,TagValue: DB 93 DBW 136
            plcRecipe.RewinderOneCharacteristicPressureContactNine = (int)_plcDal.Read(DataType.DataBlock, 93, 138, VarType.Int, 1);//Name:Recipe_entry_0_46 ,DisplayName: Pressure char. cont. roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureContact_D09,TagValue: DB 93 DBW 138
            plcRecipe.RewinderOneCharacteristicPressureContactTen = (int)_plcDal.Read(DataType.DataBlock, 93, 140, VarType.Int, 1);//Name:Recipe_entry_0_47 ,DisplayName: Pressure char. cont. roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureContact_D10,TagValue: DB 93 DBW 140

            plcRecipe.RewinderOneCharacteristicPressureContactSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 120, VarType.Int, 1);//Name:Recipe_entry_0_48 ,DisplayName:Pressure char. cont. roll rew.1 speed[%],TagName:Rew1CharacteristicPressureContactSpeedInfluence,TagValue:    DB 93 DBW 120

            plcRecipe.RewinderOneCharacteristicPressureLayOnOne = (int)_plcDal.Read(DataType.DataBlock, 93, 182, VarType.Int, 1);//Name:Recipe_entry_0_49 ,DisplayName:Pressure char. layon roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureLayOn_D01,TagValue:   DB 93 DBW 182
            plcRecipe.RewinderOneCharacteristicPressureLayOnTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 184, VarType.Int, 1);//Name:Recipe_entry_0_50 ,DisplayName:Pressure char. layon roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureLayOn_D02,TagValue:   DB 93 DBW 184
            plcRecipe.RewinderOneCharacteristicPressureLayOnThree = (int)_plcDal.Read(DataType.DataBlock, 93, 186, VarType.Int, 1);//Name:Recipe_entry_0_51 ,DisplayName:Pressure char. layon roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureLayOn_D03,TagValue:   DB 93 DBW 186
            plcRecipe.RewinderOneCharacteristicPressureLayOnFour = (int)_plcDal.Read(DataType.DataBlock, 93, 188, VarType.Int, 1);//Name:Recipe_entry_0_52 ,DisplayName:Pressure char. layon roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureLayOn_D04,TagValue:   DB 93 DBW 188
            plcRecipe.RewinderOneCharacteristicPressureLayOnFive = (int)_plcDal.Read(DataType.DataBlock, 93, 190, VarType.Int, 1);//Name:Recipe_entry_0_53 ,DisplayName:Pressure char. layon roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureLayOn_D05,TagValue:   DB 93 DBW 190
            plcRecipe.RewinderOneCharacteristicPressureLayOnSix = (int)_plcDal.Read(DataType.DataBlock, 93, 192, VarType.Int, 1);//Name:Recipe_entry_0_54 ,DisplayName:Pressure char. layon roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureLayOn_D06,TagValue:   DB 93 DBW 192
            plcRecipe.RewinderOneCharacteristicPressureLayOnSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 194, VarType.Int, 1);//Name:Recipe_entry_0_55 ,DisplayName:Pressure char. layon roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureLayOn_D07,TagValue:   DB 93 DBW 194
            plcRecipe.RewinderOneCharacteristicPressureLayOnEight = (int)_plcDal.Read(DataType.DataBlock, 93, 196, VarType.Int, 1);//Name:Recipe_entry_0_56 ,DisplayName:Pressure char. layon roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureLayOn_D08,TagValue:   DB 93 DBW 196
            plcRecipe.RewinderOneCharacteristicPressureLayOnNine = (int)_plcDal.Read(DataType.DataBlock, 93, 198, VarType.Int, 1);//Name:Recipe_entry_0_57 ,DisplayName:Pressure char. layon roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureLayOn_D09,TagValue:   DB 93 DBW 198
            plcRecipe.RewinderOneCharacteristicPressureLayOnTen = (int)_plcDal.Read(DataType.DataBlock, 93, 200, VarType.Int, 1);//Name:Recipe_entry_0_58 ,DisplayName:Pressure char. layon roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureLayOn_D010,TagValue:   DB 93 DBW 200

            plcRecipe.RewinderOneCharacteristicPressureLayOnSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 180, VarType.Int, 1);//Name:Recipe_entry_0_59 ,DisplayName: Pressure char. layon roll rew.1 speed[%],TagName:Rew1CharacteristicPressureLayOnSpeedInfluence,TagValue:  DB 93 DBW 180

            plcRecipe.RewinderTwoCharacteristicTensionOne = (int)_plcDal.Read(DataType.DataBlock, 93, 32, VarType.Int, 1);//Name:Recipe_entry_0_60 ,DisplayName:Tension characteristic rew.2 [d1][%],TagName:Rew2CharacteristicTension_D01,TagValue:   DB 93 DBW 32
            plcRecipe.RewinderTwoCharacteristicTensionTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 34, VarType.Int, 1);//Name:Recipe_entry_0_61 ,DisplayName:Tension characteristic rew.2 [d2][%],TagName:Rew2CharacteristicTension_D02,TagValue:   DB 93 DBW 34
            plcRecipe.RewinderTwoCharacteristicTensionThree = (int)_plcDal.Read(DataType.DataBlock, 93, 36, VarType.Int, 1);//Name:Recipe_entry_0_62 ,DisplayName:Tension characteristic rew.2 [d3][%],TagName:Rew2CharacteristicTension_D03,TagValue:   DB 93 DBW 36
            plcRecipe.RewinderTwoCharacteristicTensionFour = (int)_plcDal.Read(DataType.DataBlock, 93, 38, VarType.Int, 1);//Name:Recipe_entry_0_63 ,DisplayName:Tension characteristic rew.2 [d4][%],TagName:Rew2CharacteristicTension_D04,TagValue:   DB 93 DBW 38
            plcRecipe.RewinderTwoCharacteristicTensionFive = (int)_plcDal.Read(DataType.DataBlock, 93, 40, VarType.Int, 1);//Name:Recipe_entry_0_64 ,DisplayName:Tension characteristic rew.2 [d5][%],TagName:Rew2CharacteristicTension_D05,TagValue:   DB 93 DBW 40
            plcRecipe.RewinderTwoCharacteristicTensionSix = (int)_plcDal.Read(DataType.DataBlock, 93, 42, VarType.Int, 1);//Name:Recipe_entry_0_65 ,DisplayName:Tension characteristic rew.2 [d6][%],TagName:Rew2CharacteristicTension_D06,TagValue:   DB 93 DBW 42
            plcRecipe.RewinderTwoCharacteristicTensionSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 44, VarType.Int, 1);//Name:Recipe_entry_0_66 ,DisplayName:Tension characteristic rew.2 [d7][%],TagName:Rew2CharacteristicTension_D07,TagValue:   DB 93 DBW 44
            plcRecipe.RewinderTwoCharacteristicTensionEight = (int)_plcDal.Read(DataType.DataBlock, 93, 46, VarType.Int, 1);//Name:Recipe_entry_0_67 ,DisplayName:Tension characteristic rew.2 [d8][%],TagName:Rew2CharacteristicTension_D08,TagValue:   DB 93 DBW 46
            plcRecipe.RewinderTwoCharacteristicTensionNine = (int)_plcDal.Read(DataType.DataBlock, 93, 48, VarType.Int, 1);//Name:Recipe_entry_0_68 ,DisplayName:Tension characteristic rew.2 [d9][%],TagName:Rew2CharacteristicTension_D09,TagValue:   DB 93 DBW 48
            plcRecipe.RewinderTwoCharacteristicTensionTen = (int)_plcDal.Read(DataType.DataBlock, 93, 50, VarType.Int, 1);//Name:Recipe_entry_0_69 ,DisplayName:Tension characteristic rew.2 [d10][%],TagName:Rew2CharacteristicTension_D010,TagValue:   DB 93 DBW 50

            plcRecipe.RewinderTwoCharacteristicTensionSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 30, VarType.Int, 1);//Name:Recipe_entry_0_70 ,DisplayName:Tension characteristic rew.2 speed[%],TagName:Rew2CharacteristicTensionSpeedInfluence,TagValue: DB 93 DBW 30

            plcRecipe.RewinderTwoCharacteristicPressureContactOne = (int)_plcDal.Read(DataType.DataBlock, 93, 152, VarType.Int, 1);//Name:Recipe_entry_0_71 ,DisplayName:Pressure char. cont. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureContact_D01,TagValue:  DB 93 DBW 152
            plcRecipe.RewinderTwoCharacteristicPressureContactTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 154, VarType.Int, 1);//Name:Recipe_entry_0_72 ,DisplayName:Pressure char. cont. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureContact_D02,TagValue:  DB 93 DBW 154
            plcRecipe.RewinderTwoCharacteristicPressureContactThree = (int)_plcDal.Read(DataType.DataBlock, 93, 156, VarType.Int, 1);//Name:Recipe_entry_0_73 ,DisplayName:Pressure char. cont. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureContact_D03,TagValue:  DB 93 DBW 156
            plcRecipe.RewinderTwoCharacteristicPressureContactFour = (int)_plcDal.Read(DataType.DataBlock, 93, 158, VarType.Int, 1);//Name:Recipe_entry_0_74 ,DisplayName:Pressure char. cont. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureContact_D04,TagValue:  DB 93 DBW 158
            plcRecipe.RewinderTwoCharacteristicPressureContactFive = (int)_plcDal.Read(DataType.DataBlock, 93, 160, VarType.Int, 1);//Name:Recipe_entry_0_75 ,DisplayName:Pressure char. cont. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureContact_D05,TagValue:  DB 93 DBW 160
            plcRecipe.RewinderTwoCharacteristicPressureContactSix = (int)_plcDal.Read(DataType.DataBlock, 93, 162, VarType.Int, 1);//Name:Recipe_entry_0_76 ,DisplayName:Pressure char. cont. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureContact_D06,TagValue:  DB 93 DBW 162
            plcRecipe.RewinderTwoCharacteristicPressureContactSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 164, VarType.Int, 1);//Name:Recipe_entry_0_77 ,DisplayName:Pressure char. cont. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureContact_D07,TagValue:  DB 93 DBW 164
            plcRecipe.RewinderTwoCharacteristicPressureContactEight = (int)_plcDal.Read(DataType.DataBlock, 93, 166, VarType.Int, 1);//Name:Recipe_entry_0_78 ,DisplayName:Pressure char. cont. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureContact_D08,TagValue:  DB 93 DBW 166
            plcRecipe.RewinderTwoCharacteristicPressureContactNine = (int)_plcDal.Read(DataType.DataBlock, 93, 168, VarType.Int, 1);//Name:Recipe_entry_0_79 ,DisplayName:Pressure char. cont. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureContact_D09,TagValue:  DB 93 DBW 168
            plcRecipe.RewinderTwoCharacteristicPressureContactTen = (int)_plcDal.Read(DataType.DataBlock, 93, 170, VarType.Int, 1);//Name:Recipe_entry_0_80 ,DisplayName:Pressure char. cont. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureContact_D010,TagValue:  DB 93 DBW 170

            plcRecipe.RewinderTwoCharacteristicPressureContactSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 150, VarType.Int, 1);//Name:Recipe_entry_0_81 ,DisplayName: Pressure char. cont. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureContactSpeedInfluence,TagValue: DB 93 DBW 150

            plcRecipe.RewinderTwoCharacteristicPressureSupportOne = (int)_plcDal.Read(DataType.DataBlock, 93, 212, VarType.Int, 1);//Name:Recipe_entry_0_82 ,DisplayName:Pressure char. supp. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureSupport_D01,TagValue:DB 93 DBW 212
            plcRecipe.RewinderTwoCharacteristicPressureSupportTwo = (int)_plcDal.Read(DataType.DataBlock, 93, 214, VarType.Int, 1);//Name:Recipe_entry_0_83 ,DisplayName:Pressure char. supp. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureSupport_D02,TagValue:DB 93 DBW 214
            plcRecipe.RewinderTwoCharacteristicPressureSupportThree = (int)_plcDal.Read(DataType.DataBlock, 93, 216, VarType.Int, 1);//Name:Recipe_entry_0_84 ,DisplayName:Pressure char. supp. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureSupport_D03,TagValue:DB 93 DBW 216
            plcRecipe.RewinderTwoCharacteristicPressureSupportFour = (int)_plcDal.Read(DataType.DataBlock, 93, 218, VarType.Int, 1);//Name:Recipe_entry_0_85 ,DisplayName:Pressure char. supp. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureSupport_D04,TagValue:DB 93 DBW 218
            plcRecipe.RewinderTwoCharacteristicPressureSupportFive = (int)_plcDal.Read(DataType.DataBlock, 93, 220, VarType.Int, 1);//Name:Recipe_entry_0_86 ,DisplayName:Pressure char. supp. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureSupport_D05,TagValue:DB 93 DBW 220
            plcRecipe.RewinderTwoCharacteristicPressureSupportSix = (int)_plcDal.Read(DataType.DataBlock, 93, 222, VarType.Int, 1);//Name:Recipe_entry_0_87 ,DisplayName:Pressure char. supp. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureSupport_D06,TagValue:DB 93 DBW 222
            plcRecipe.RewinderTwoCharacteristicPressureSupportSeven = (int)_plcDal.Read(DataType.DataBlock, 93, 224, VarType.Int, 1);//Name:Recipe_entry_0_88 ,DisplayName:Pressure char. supp. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureSupport_D07,TagValue:DB 93 DBW 224
            plcRecipe.RewinderTwoCharacteristicPressureSupportEight = (int)_plcDal.Read(DataType.DataBlock, 93, 226, VarType.Int, 1);//Name:Recipe_entry_0_89 ,DisplayName:Pressure char. supp. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureSupport_D08,TagValue:DB 93 DBW 226
            plcRecipe.RewinderTwoCharacteristicPressureSupportNine = (int)_plcDal.Read(DataType.DataBlock, 93, 228, VarType.Int, 1);//Name:Recipe_entry_0_90 ,DisplayName:Pressure char. supp. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureSupport_D09,TagValue:DB 93 DBW 228
            plcRecipe.RewinderTwoCharacteristicPressureSupportTen = (int)_plcDal.Read(DataType.DataBlock, 93, 230, VarType.Int, 1);//Name:Recipe_entry_0_91 ,DisplayName:Pressure char. supp. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureSupport_D010,TagValue:DB 93 DBW 230

            plcRecipe.RewinderTwoCharacteristicPressureSupportSpeedInfluence = (int)_plcDal.Read(DataType.DataBlock, 93, 210, VarType.Int, 1);//Name:Recipe_entry_0_92 ,DisplayName: Pressure char. supp. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureSupportSpeedInfluence,TagValue:  DB 93 DBW 210

            return new SuccessDataResult<PLCRecipe>(plcRecipe, PLCRecipeMessages.Read);
        }
        public async Task<IResult> WriteRecipe(PLCRecipe plcRecipe)
        {

            _plcDal.Write(DataType.DataBlock, 96, 40, plcRecipe.RecipeNumber);//TagName:RecipeNumber,TagValue:DB 96 DBW 40
            _plcDal.Write(DataType.DataBlock, 91, 36, plcRecipe.MaterialThickness);//Name:Recipe_entry_0_0,DisplayName: Material thickness [µm],TagName:MaterialThickness,TagValue:DB 91 DBW 36
            _plcDal.Write(DataType.DataBlock, 91, 310, plcRecipe.RewinderOneMaterialWidth);//Name:Recipe_entry_0_1 ,DisplayName:Material width rewinder [mm] ,TagName:Rew1MaterialWidth,TagValue: DB 91 DBW 310
            _plcDal.Write(DataType.DataBlock, 91, 2, plcRecipe.MachineSpeedSet);//Name:Recipe_entry_0_2 ,DisplayName: Set speed [m/min] ,TagName:MachineSpeedSet,TagValue: DB 91 DBW 2
            _plcDal.Write(DataType.DataBlock, 91, 100, plcRecipe.UnwinderOneDiameterSet);//Name:Recipe_entry_0_3 ,DisplayName:  Set diameter unwinder [mm] ,TagName:Unw1DiaSet,TagValue: DB 91 DBW 100
            _plcDal.Write(DataType.DataBlock, 91, 300, plcRecipe.RewinderOneDiameterSet);//Name:Recipe_entry_0_4 ,DisplayName: Set diameter rewinder 1 [mm],TagName:Rew1DiaSet,TagValue:  DB 91 DBW 300
            _plcDal.Write(DataType.DataBlock, 91, 306, plcRecipe.RewinderOneLengthSet);//Name:Recipe_entry_0_5 ,DisplayName: Set length rewinder 1  [m] Set diameter rewinder 1 [mm] ,TagName:Rew1LengthSet,TagValue:  DB 91 DBD 306
            _plcDal.Write(DataType.DataBlock, 91, 312, plcRecipe.RewinderOneTensionSetScaled);//Name:Recipe_entry_0_6 ,DisplayName:  Tension rewinder 1 [N/mm²] ,TagName:Rew1TensionSetScaled,TagValue:  DB 91 DBW 312
            _plcDal.Write(DataType.DataBlock, 91, 342, plcRecipe.RewinderOneTensionContactSetScaled);//Name:Recipe_entry_0_7 ,DisplayName: Tension contact roll rewinder 1  [N/mm²],TagName:Rew1TensionContSetScaled,TagValue:  DB 91 DBW 342
            _plcDal.Write(DataType.DataBlock, 91, 372, plcRecipe.RewinderOneTensionLaySetScaled);//Name:Recipe_entry_0_8  ,DisplayName:Tension layon roll rewinder 1 [N/mm²],TagName:Rew1TensionLaySetScaled,TagValue:  DB 91 DBW 372
            _plcDal.Write(DataType.DataBlock, 91, 336, plcRecipe.RewinderOnePressureContactBalance);//Name:Recipe_entry_0_10  ,DisplayName: Balance contact roll rewinder 1 [%],TagName:Rew1PresContBalance,TagValue:  DB 91 DBW 336
            _plcDal.Write(DataType.DataBlock, 91, 352, plcRecipe.RewinderOnePressureLaySetScaled);//Name:Recipe_entry_0_11  ,DisplayName:  Pressure layon roll rewinder 1 [N/mm],TagName:Rew1PresLaySetScaled,TagValue:  DB 91 DBW 352
            _plcDal.Write(DataType.DataBlock, 91, 366, plcRecipe.RewinderOnePressureLayBalance);//Name:Recipe_entry_0_12  ,DisplayName: Balance layon roll rewinder 1 [%],TagName:Rew1PresLayBalance,TagValue: DB 91 DBW 366
            _plcDal.Write(DataType.DataBlock, 91, 400, plcRecipe.RewinderTwoDiameterSet);//Name:Recipe_entry_0_13  ,DisplayName: Set diameter rewinder 2  [mm],TagName:Rew2DiaSet,TagValue:  DB 91 DBW 400
            _plcDal.Write(DataType.DataBlock, 91, 406, plcRecipe.RewinderTwoLengthSet);//Name:Recipe_entry_0_14  ,DisplayName: Set length rewinder 2 [m],TagName:Rew2LengthSet,TagValue: DB 91 DBD 406
            _plcDal.Write(DataType.DataBlock, 91, 412, plcRecipe.RewinderTwoTensionSetScaled);//Name:Recipe_entry_0_15  ,DisplayName: Tension rewinder 2 [N/mm²],TagName:Rew2TensionSetScaled,TagValue:  DB 91 DBW 412
            _plcDal.Write(DataType.DataBlock, 91, 442, plcRecipe.RewinderTwoTensionContactSetScaled);//Name:Recipe_entry_0_16  ,DisplayName:  Tension contact roll rewinder 2  [N/mm²],TagName:Rew2TensionContSetScaled,TagValue:   DB 91 DBW 442
            _plcDal.Write(DataType.DataBlock, 91, 472, plcRecipe.RewinderTwoTensionSupportSetScaled);//Name:Recipe_entry_0_17  ,DisplayName: Tension support roll rewinder 2  [N/mm²],TagName:Rew2TensionSupSetScaled,TagValue:  DB 91 DBW 472
            _plcDal.Write(DataType.DataBlock, 91, 422, plcRecipe.RewinderTwoPressureContactSetScaled);//Name:Recipe_entry_0_18  ,DisplayName: Pressure contact roll rewinder 2  [N/mm],TagName:Rew2PresContSetScaled,TagValue:  DB 91 DBW 422
            _plcDal.Write(DataType.DataBlock, 91, 436, plcRecipe.RewinderTwoPressureContactBalance);//Name:Recipe_entry_0_19  ,DisplayName: Balance pres. cont. roll rew. 2[%],TagName:Rew2PresContBalance,TagValue:  DB 91 DBW 436
            _plcDal.Write(DataType.DataBlock, 91, 452, plcRecipe.RewinderTwoPressureSupportSetScaled);//Name:Recipe_entry_0_20  ,DisplayName: Pressure support roll rewinder 2  [N/mm],TagName:Rew2PresSupSetScaled,TagValue:DB 91 DBW 452
            _plcDal.Write(DataType.DataBlock, 91, 466, plcRecipe.RewinderTwoPressureSupportBalance);//Name:Recipe_entry_0_21  ,DisplayName:Balance pres. sup. roll rew. 2 [%] ,TagName:Rew2PresSupBalance,TagValue: DB 91 DBW 466
            _plcDal.Write(DataType.DataBlock, 91, 8, plcRecipe.MachineTimeAcceleration);//Name:Recipe_entry_0_22  ,DisplayName: Acceleration time [s],TagName:MachineTimeAccel,TagValue:DB 91 DBW 8
            _plcDal.Write(DataType.DataBlock, 91, 10, plcRecipe.MachineTimeDecelarition);//Name:Recipe_entry_0_23  ,DisplayName:Deceleration time [s] ,TagName:MachineTimeDecel,TagValue:DB 91 DBW 10
            _plcDal.Write(DataType.DataBlock, 91, 12, plcRecipe.MachineTimeFastStop);//Name:Recipe_entry_0_24  ,DisplayName: Fast stop time [s] ,TagName:MachineTimeFastStop,TagValue:  DB 91 DBW 12
            _plcDal.Write(DataType.DataBlock, 91, 550, plcRecipe.TransportTensionSet);//Name:Recipe_entry_0_25  ,DisplayName: Set tension transport rolls [%] ,TagName:TransportTensionSet,TagValue:  DB 91 DBW 550
            _plcDal.Write(DataType.DataBlock, 91, 80, plcRecipe.MachineWeldingSpeedSet);//Name:Recipe_entry_0_26   ,DisplayName:Welding speed [mm/s],TagName:MachineWeldingSpeedSet,TagValue:  DB 91 DBW 80

            _plcDal.Write(DataType.DataBlock, 93, 2, plcRecipe.RewinderOneCharacteristicTensionOne);//Name:Recipe_entry_0_27  ,DisplayName:Tension characteristic rew.1 [di][%] ,TagName:Rew1CharacteristicTension_D01,TagValue: DB 93 DBW 2
            _plcDal.Write(DataType.DataBlock, 93, 4, plcRecipe.RewinderOneCharacteristicTensionTwo);//Name:Recipe_entry_0_28  ,DisplayName:Tension characteristic rew.1 [d2][%],TagName:Rew1CharacteristicTension_D02,TagValue:  DB 93 DBW 4
            _plcDal.Write(DataType.DataBlock, 93, 6, plcRecipe.RewinderOneCharacteristicTensionThree);//Name:Recipe_entry_0_29  ,DisplayName:Tension characteristic rew.1 [d3][%],TagName:Rew1CharacteristicTension_D03,TagValue:  DB 93 DBW 6
            _plcDal.Write(DataType.DataBlock, 93, 8, plcRecipe.RewinderOneCharacteristicTensionFour);//Name:Recipe_entry_0_30  ,DisplayName:Tension characteristic rew.1 [d4][%],TagName:Rew1CharacteristicTension_D04,TagValue:  DB 93 DBW 8
            _plcDal.Write(DataType.DataBlock, 93, 10, plcRecipe.RewinderOneCharacteristicTensionFive);//Name:Recipe_entry_0_31  ,DisplayName:Tension characteristic rew.1 [d5][%],TagName:Rew1CharacteristicTension_D05,TagValue:  DB 93 DBW 10
            _plcDal.Write(DataType.DataBlock, 93, 12, plcRecipe.RewinderOneCharacteristicTensionSix);//Name:Recipe_entry_0_32 ,DisplayName:Tension characteristic rew.1 [d6][%],TagName:Rew1CharacteristicTension_D06,TagValue:  DB 93 DBW 12
            _plcDal.Write(DataType.DataBlock, 93, 14, plcRecipe.RewinderOneCharacteristicTensionSeven);//Name:Recipe_entry_0_33  ,DisplayName:Tension characteristic rew.1 [d7][%],TagName:Rew1CharacteristicTension_D07,TagValue:  DB 93 DBW 14
            _plcDal.Write(DataType.DataBlock, 93, 16, plcRecipe.RewinderOneCharacteristicTensionEight);//Name:Recipe_entry_0_34  ,DisplayName:Tension characteristic rew.1 [d8][%],TagName:Rew1CharacteristicTension_D08,TagValue:  DB 93 DBW 16
            _plcDal.Write(DataType.DataBlock, 93, 18, plcRecipe.RewinderOneCharacteristicTensionNine);//Name:Recipe_entry_0_35 ,DisplayName:Tension characteristic rew.1 [d9][%],TagName:Rew1CharacteristicTension_D09,TagValue:  DB 93 DBW 18
            _plcDal.Write(DataType.DataBlock, 93, 20, plcRecipe.RewinderOneCharacteristicTensionTen);//Name:Recipe_entry_0_36 ,DisplayName:Tension characteristic rew.1 [d10][%],TagName:Rew1CharacteristicTension_D010,TagValue:  DB 93 DBW 20

            _plcDal.Write(DataType.DataBlock, 93, 0, plcRecipe.RewinderOneCharacteristicTensionSpeedInfluence);//Name:Recipe_entry_0_37 ,DisplayName:Tension characteristic rew.1 speed   [%],TagName:Rew1CharacteristicTensionSpeedInfluence,TagValue:    DB 93 DBW 0

            _plcDal.Write(DataType.DataBlock, 93, 122, plcRecipe.RewinderOneCharacteristicPressureContactOne);//Name:Recipe_entry_0_38 ,DisplayName: Pressure char. cont. roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureContact_D01,TagValue: DB 93 DBW 122
            _plcDal.Write(DataType.DataBlock, 93, 124, plcRecipe.RewinderOneCharacteristicPressureContactTwo);//Name:Recipe_entry_0_39 ,DisplayName: Pressure char. cont. roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureContact_D02,TagValue: DB 93 DBW 124
            _plcDal.Write(DataType.DataBlock, 93, 126, plcRecipe.RewinderOneCharacteristicPressureContactThree);//Name:Recipe_entry_0_40 ,DisplayName: Pressure char. cont. roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureContact_D03,TagValue: DB 93 DBW 126
            _plcDal.Write(DataType.DataBlock, 93, 128, plcRecipe.RewinderOneCharacteristicPressureContactFour);//Name:Recipe_entry_0_41 ,DisplayName: Pressure char. cont. roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 128
            _plcDal.Write(DataType.DataBlock, 93, 130, plcRecipe.RewinderOneCharacteristicPressureContactFive);//Name:Recipe_entry_0_42 ,DisplayName: Pressure char. cont. roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureContact_D04,TagValue: DB 93 DBW 130
            _plcDal.Write(DataType.DataBlock, 93, 132, plcRecipe.RewinderOneCharacteristicPressureContactSix);//Name:Recipe_entry_0_43 ,DisplayName: Pressure char. cont. roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureContact_D06,TagValue: DB 93 DBW 132
            _plcDal.Write(DataType.DataBlock, 93, 134, plcRecipe.RewinderOneCharacteristicPressureContactSeven);//Name:Recipe_entry_0_44 ,DisplayName: Pressure char. cont. roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureContact_D07,TagValue: DB 93 DBW 134
            _plcDal.Write(DataType.DataBlock, 93, 136, plcRecipe.RewinderOneCharacteristicPressureContactEight);//Name:Recipe_entry_0_45 ,DisplayName: Pressure char. cont. roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureContact_D08,TagValue: DB 93 DBW 136
            _plcDal.Write(DataType.DataBlock, 93, 138, plcRecipe.RewinderOneCharacteristicPressureContactNine);//Name:Recipe_entry_0_46 ,DisplayName: Pressure char. cont. roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureContact_D09,TagValue: DB 93 DBW 138
            _plcDal.Write(DataType.DataBlock, 93, 140, plcRecipe.RewinderOneCharacteristicPressureContactTen);//Name:Recipe_entry_0_47 ,DisplayName: Pressure char. cont. roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureContact_D10,TagValue: DB 93 DBW 140

            _plcDal.Write(DataType.DataBlock, 93, 120, plcRecipe.RewinderOneCharacteristicPressureContactSpeedInfluence);//Name:Recipe_entry_0_48 ,DisplayName:Pressure char. cont. roll rew.1 speed[%],TagName:Rew1CharacteristicPressureContactSpeedInfluence,TagValue:    DB 93 DBW 120

            _plcDal.Write(DataType.DataBlock, 93, 182, plcRecipe.RewinderOneCharacteristicPressureLayOnOne);//Name:Recipe_entry_0_49 ,DisplayName:Pressure char. layon roll rew.1 [d1][%],TagName:Rew1CharacteristicPressureLayOn_D01,TagValue:   DB 93 DBW 182
            _plcDal.Write(DataType.DataBlock, 93, 184, plcRecipe.RewinderOneCharacteristicPressureLayOnTwo);//Name:Recipe_entry_0_50 ,DisplayName:Pressure char. layon roll rew.1 [d2][%],TagName:Rew1CharacteristicPressureLayOn_D02,TagValue:   DB 93 DBW 184
            _plcDal.Write(DataType.DataBlock, 93, 186, plcRecipe.RewinderOneCharacteristicPressureLayOnThree);//Name:Recipe_entry_0_51 ,DisplayName:Pressure char. layon roll rew.1 [d3][%],TagName:Rew1CharacteristicPressureLayOn_D03,TagValue:   DB 93 DBW 186
            _plcDal.Write(DataType.DataBlock, 93, 188, plcRecipe.RewinderOneCharacteristicPressureLayOnFour);//Name:Recipe_entry_0_52 ,DisplayName:Pressure char. layon roll rew.1 [d4][%],TagName:Rew1CharacteristicPressureLayOn_D04,TagValue:   DB 93 DBW 188
            _plcDal.Write(DataType.DataBlock, 93, 190, plcRecipe.RewinderOneCharacteristicPressureLayOnFive);//Name:Recipe_entry_0_53 ,DisplayName:Pressure char. layon roll rew.1 [d5][%],TagName:Rew1CharacteristicPressureLayOn_D05,TagValue:   DB 93 DBW 190
            _plcDal.Write(DataType.DataBlock, 93, 192, plcRecipe.RewinderOneCharacteristicPressureLayOnSix);//Name:Recipe_entry_0_54 ,DisplayName:Pressure char. layon roll rew.1 [d6][%],TagName:Rew1CharacteristicPressureLayOn_D06,TagValue:   DB 93 DBW 192
            _plcDal.Write(DataType.DataBlock, 93, 194, plcRecipe.RewinderOneCharacteristicPressureLayOnSeven);//Name:Recipe_entry_0_55 ,DisplayName:Pressure char. layon roll rew.1 [d7][%],TagName:Rew1CharacteristicPressureLayOn_D07,TagValue:   DB 93 DBW 194
            _plcDal.Write(DataType.DataBlock, 93, 196, plcRecipe.RewinderOneCharacteristicPressureLayOnEight);//Name:Recipe_entry_0_56 ,DisplayName:Pressure char. layon roll rew.1 [d8][%],TagName:Rew1CharacteristicPressureLayOn_D08,TagValue:   DB 93 DBW 196
            _plcDal.Write(DataType.DataBlock, 93, 198, plcRecipe.RewinderOneCharacteristicPressureLayOnNine);//Name:Recipe_entry_0_57 ,DisplayName:Pressure char. layon roll rew.1 [d9][%],TagName:Rew1CharacteristicPressureLayOn_D09,TagValue:   DB 93 DBW 198
            _plcDal.Write(DataType.DataBlock, 93, 200, plcRecipe.RewinderOneCharacteristicPressureLayOnTen);//Name:Recipe_entry_0_58 ,DisplayName:Pressure char. layon roll rew.1 [d10][%],TagName:Rew1CharacteristicPressureLayOn_D010,TagValue:   DB 93 DBW 200

            _plcDal.Write(DataType.DataBlock, 93, 180, plcRecipe.RewinderOneCharacteristicPressureLayOnSpeedInfluence);//Name:Recipe_entry_0_59 ,DisplayName: Pressure char. layon roll rew.1 speed[%],TagName:Rew1CharacteristicPressureLayOnSpeedInfluence,TagValue:  DB 93 DBW 180

            _plcDal.Write(DataType.DataBlock, 93, 32, plcRecipe.RewinderTwoCharacteristicTensionOne);//Name:Recipe_entry_0_60 ,DisplayName:Tension characteristic rew.2 [d1][%],TagName:Rew2CharacteristicTension_D01,TagValue:   DB 93 DBW 32
            _plcDal.Write(DataType.DataBlock, 93, 34, plcRecipe.RewinderTwoCharacteristicTensionTwo);//Name:Recipe_entry_0_61 ,DisplayName:Tension characteristic rew.2 [d2][%],TagName:Rew2CharacteristicTension_D02,TagValue:   DB 93 DBW 34
            _plcDal.Write(DataType.DataBlock, 93, 36, plcRecipe.RewinderTwoCharacteristicTensionThree);//Name:Recipe_entry_0_62 ,DisplayName:Tension characteristic rew.2 [d3][%],TagName:Rew2CharacteristicTension_D03,TagValue:   DB 93 DBW 36
            _plcDal.Write(DataType.DataBlock, 93, 38, plcRecipe.RewinderTwoCharacteristicTensionFour);//Name:Recipe_entry_0_63 ,DisplayName:Tension characteristic rew.2 [d4][%],TagName:Rew2CharacteristicTension_D04,TagValue:   DB 93 DBW 38
            _plcDal.Write(DataType.DataBlock, 93, 40, plcRecipe.RewinderTwoCharacteristicTensionFive);//Name:Recipe_entry_0_64 ,DisplayName:Tension characteristic rew.2 [d5][%],TagName:Rew2CharacteristicTension_D05,TagValue:   DB 93 DBW 40
            _plcDal.Write(DataType.DataBlock, 93, 42, plcRecipe.RewinderTwoCharacteristicTensionSix);//Name:Recipe_entry_0_65 ,DisplayName:Tension characteristic rew.2 [d6][%],TagName:Rew2CharacteristicTension_D06,TagValue:   DB 93 DBW 42
            _plcDal.Write(DataType.DataBlock, 93, 44, plcRecipe.RewinderTwoCharacteristicTensionSeven);//Name:Recipe_entry_0_66 ,DisplayName:Tension characteristic rew.2 [d7][%],TagName:Rew2CharacteristicTension_D07,TagValue:   DB 93 DBW 44
            _plcDal.Write(DataType.DataBlock, 93, 46, plcRecipe.RewinderTwoCharacteristicTensionEight);//Name:Recipe_entry_0_67 ,DisplayName:Tension characteristic rew.2 [d8][%],TagName:Rew2CharacteristicTension_D08,TagValue:   DB 93 DBW 46
            _plcDal.Write(DataType.DataBlock, 93, 48, plcRecipe.RewinderTwoCharacteristicTensionNine);//Name:Recipe_entry_0_68 ,DisplayName:Tension characteristic rew.2 [d9][%],TagName:Rew2CharacteristicTension_D09,TagValue:   DB 93 DBW 48
            _plcDal.Write(DataType.DataBlock, 93, 50, plcRecipe.RewinderTwoCharacteristicTensionTen);//Name:Recipe_entry_0_69 ,DisplayName:Tension characteristic rew.2 [d10][%],TagName:Rew2CharacteristicTension_D010,TagValue:   DB 93 DBW 50

            _plcDal.Write(DataType.DataBlock, 93, 30, plcRecipe.RewinderTwoCharacteristicTensionSpeedInfluence);//Name:Recipe_entry_0_70 ,DisplayName:Tension characteristic rew.2 speed[%],TagName:Rew2CharacteristicTensionSpeedInfluence,TagValue: DB 93 DBW 30

            _plcDal.Write(DataType.DataBlock, 93, 152, plcRecipe.RewinderTwoCharacteristicPressureContactOne);//Name:Recipe_entry_0_71 ,DisplayName:Pressure char. cont. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureContact_D01,TagValue:  DB 93 DBW 152
            _plcDal.Write(DataType.DataBlock, 93, 154, plcRecipe.RewinderTwoCharacteristicPressureContactTwo);//Name:Recipe_entry_0_72 ,DisplayName:Pressure char. cont. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureContact_D02,TagValue:  DB 93 DBW 154
            _plcDal.Write(DataType.DataBlock, 93, 156, plcRecipe.RewinderTwoCharacteristicPressureContactThree);//Name:Recipe_entry_0_73 ,DisplayName:Pressure char. cont. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureContact_D03,TagValue:  DB 93 DBW 156
            _plcDal.Write(DataType.DataBlock, 93, 158, plcRecipe.RewinderTwoCharacteristicPressureContactFour);//Name:Recipe_entry_0_74 ,DisplayName:Pressure char. cont. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureContact_D04,TagValue:  DB 93 DBW 158
            _plcDal.Write(DataType.DataBlock, 93, 160, plcRecipe.RewinderTwoCharacteristicPressureContactFive);//Name:Recipe_entry_0_75 ,DisplayName:Pressure char. cont. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureContact_D05,TagValue:  DB 93 DBW 160
            _plcDal.Write(DataType.DataBlock, 93, 162, plcRecipe.RewinderTwoCharacteristicPressureContactSix);//Name:Recipe_entry_0_76 ,DisplayName:Pressure char. cont. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureContact_D06,TagValue:  DB 93 DBW 162
            _plcDal.Write(DataType.DataBlock, 93, 164, plcRecipe.RewinderTwoCharacteristicPressureContactSeven);//Name:Recipe_entry_0_77 ,DisplayName:Pressure char. cont. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureContact_D07,TagValue:  DB 93 DBW 164
            _plcDal.Write(DataType.DataBlock, 93, 166, plcRecipe.RewinderTwoCharacteristicPressureContactEight);//Name:Recipe_entry_0_78 ,DisplayName:Pressure char. cont. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureContact_D08,TagValue:  DB 93 DBW 166
            _plcDal.Write(DataType.DataBlock, 93, 168, plcRecipe.RewinderTwoCharacteristicPressureContactNine);//Name:Recipe_entry_0_79 ,DisplayName:Pressure char. cont. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureContact_D09,TagValue:  DB 93 DBW 168
            _plcDal.Write(DataType.DataBlock, 93, 170, plcRecipe.RewinderTwoCharacteristicPressureContactTen);//Name:Recipe_entry_0_80 ,DisplayName:Pressure char. cont. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureContact_D010,TagValue:  DB 93 DBW 170

            _plcDal.Write(DataType.DataBlock, 93, 150, plcRecipe.RewinderTwoCharacteristicPressureContactSpeedInfluence);//Name:Recipe_entry_0_81 ,DisplayName: Pressure char. cont. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureContactSpeedInfluence,TagValue: DB 93 DBW 150

            _plcDal.Write(DataType.DataBlock, 93, 212, plcRecipe.RewinderTwoCharacteristicPressureSupportOne);//Name:Recipe_entry_0_82 ,DisplayName:Pressure char. supp. roll rew.2 [d1][%],TagName:Rew2CharacteristicPressureSupport_D01,TagValue:DB 93 DBW 212
            _plcDal.Write(DataType.DataBlock, 93, 214, plcRecipe.RewinderTwoCharacteristicPressureSupportTwo);//Name:Recipe_entry_0_83 ,DisplayName:Pressure char. supp. roll rew.2 [d2][%],TagName:Rew2CharacteristicPressureSupport_D02,TagValue:DB 93 DBW 214
            _plcDal.Write(DataType.DataBlock, 93, 216, plcRecipe.RewinderTwoCharacteristicPressureSupportThree);//Name:Recipe_entry_0_84 ,DisplayName:Pressure char. supp. roll rew.2 [d3][%],TagName:Rew2CharacteristicPressureSupport_D03,TagValue:DB 93 DBW 216
            _plcDal.Write(DataType.DataBlock, 93, 218, plcRecipe.RewinderTwoCharacteristicPressureSupportFour);//Name:Recipe_entry_0_85 ,DisplayName:Pressure char. supp. roll rew.2 [d4][%],TagName:Rew2CharacteristicPressureSupport_D04,TagValue:DB 93 DBW 218
            _plcDal.Write(DataType.DataBlock, 93, 220, plcRecipe.RewinderTwoCharacteristicPressureSupportFive);//Name:Recipe_entry_0_86 ,DisplayName:Pressure char. supp. roll rew.2 [d5][%],TagName:Rew2CharacteristicPressureSupport_D05,TagValue:DB 93 DBW 220
            _plcDal.Write(DataType.DataBlock, 93, 222, plcRecipe.RewinderTwoCharacteristicPressureSupportSix);//Name:Recipe_entry_0_87 ,DisplayName:Pressure char. supp. roll rew.2 [d6][%],TagName:Rew2CharacteristicPressureSupport_D06,TagValue:DB 93 DBW 222
            _plcDal.Write(DataType.DataBlock, 93, 224, plcRecipe.RewinderTwoCharacteristicPressureSupportSeven);//Name:Recipe_entry_0_88 ,DisplayName:Pressure char. supp. roll rew.2 [d7][%],TagName:Rew2CharacteristicPressureSupport_D07,TagValue:DB 93 DBW 224
            _plcDal.Write(DataType.DataBlock, 93, 226, plcRecipe.RewinderTwoCharacteristicPressureSupportEight);//Name:Recipe_entry_0_89 ,DisplayName:Pressure char. supp. roll rew.2 [d8][%],TagName:Rew2CharacteristicPressureSupport_D08,TagValue:DB 93 DBW 226
            _plcDal.Write(DataType.DataBlock, 93, 228, plcRecipe.RewinderTwoCharacteristicPressureSupportNine);//Name:Recipe_entry_0_90 ,DisplayName:Pressure char. supp. roll rew.2 [d9][%],TagName:Rew2CharacteristicPressureSupport_D09,TagValue:DB 93 DBW 228
            _plcDal.Write(DataType.DataBlock, 93, 230, plcRecipe.RewinderTwoCharacteristicPressureSupportTen);//Name:Recipe_entry_0_91 ,DisplayName:Pressure char. supp. roll rew.2 [d10][%],TagName:Rew2CharacteristicPressureSupport_D010,TagValue:DB 93 DBW 230

            _plcDal.Write(DataType.DataBlock, 93, 210, plcRecipe.RewinderTwoCharacteristicPressureSupportSpeedInfluence);//Name:Recipe_entry_0_92 ,DisplayName: Pressure char. supp. roll rew.2 speed[%],TagName:Rew2CharacteristicPressureSupportSpeedInfluence,TagValue:  DB 93 DBW 210

            return new SuccessResult(PLCRecipeMessages.Write);
        }



    }
}
