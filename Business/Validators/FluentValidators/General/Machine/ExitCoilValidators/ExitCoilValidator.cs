using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.ExitCoilValidators
{
    public class ExitCoilValidator : AbstractValidator<ExitCoil>
    {
        public ExitCoilValidator()
        {
            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.ProductionStart).NotEmpty();
            RuleFor(x => x.ProductionStart).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ProductionEnd).NotEmpty();
            RuleFor(x => x.ProductionEnd).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.FlagConsumed).NotEmpty();
            RuleFor(x => x.FlagConsumed).Length(1, 20);

            RuleFor(x => x.OuterDiameter).NotEmpty();
            RuleFor(x => x.OuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ExitCoilLength).NotEmpty();
            RuleFor(x => x.ExitCoilLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ExitInnerDiameter).NotEmpty();
            RuleFor(x => x.ExitInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SpoolTypeAsas).NotEmpty();
            RuleFor(x => x.SpoolTypeAsas).Length(1, 40);

            RuleFor(x => x.TensionerBottom).NotEmpty();
            RuleFor(x => x.TensionerBottom).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.TensionerTop).NotEmpty();
            RuleFor(x => x.TensionerTop).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ThicknessInspectionTop).NotEmpty();
            RuleFor(x => x.ThicknessInspectionTop).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.ThicknessInspectionBottom).NotEmpty();
            RuleFor(x => x.ThicknessInspectionBottom).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.WindingSenseExitOne).NotEmpty();
            RuleFor(x => x.WindingSenseExitOne).Length(1, 20);

            RuleFor(x => x.WindingSenseExitTwo).NotEmpty();
            RuleFor(x => x.WindingSenseExitTwo).Length(1, 20);

            RuleFor(x => x.WindingSenseEntry).NotEmpty();
            RuleFor(x => x.WindingSenseEntry).Length(1, 20);

            RuleFor(x => x.SlitBaseNumber).NotEmpty();
            RuleFor(x => x.SlitBaseNumber).Length(1, 60);

            RuleFor(x => x.OperatorName).NotEmpty();
            RuleFor(x => x.OperatorName).Length(1, 60);

            RuleFor(x => x.TransporterOneMinimumTension).NotEmpty();
            RuleFor(x => x.TransporterOneMinimumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterOneMaximumTension).NotEmpty();
            RuleFor(x => x.TransporterOneMaximumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterOneAverageTension).NotEmpty();
            RuleFor(x => x.TransporterOneAverageTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoMinimumTension).NotEmpty();
            RuleFor(x => x.TransporterTwoMinimumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoMaximumTension).NotEmpty();
            RuleFor(x => x.TransporterTwoMaximumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoAverageTension).NotEmpty();
            RuleFor(x => x.TransporterTwoAverageTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneMinimumContactPressure).NotEmpty();
            RuleFor(x => x.RewinderOneMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneMaximumContactPressure).NotEmpty();
            RuleFor(x => x.RewinderOneMaximumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WorkRollTopDiameter).NotEmpty();
            RuleFor(x => x.WorkRollTopDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneAverageContactPressure).NotEmpty();
            RuleFor(x => x.RewinderOneAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMinimumContactPressure).NotEmpty();
            RuleFor(x => x.RewinderTwoMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMaximumContactPressure).NotEmpty();
            RuleFor(x => x.RewinderTwoMaximumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoAverageContactPressure).NotEmpty();
            RuleFor(x => x.RewinderTwoAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneTensionMaximum).NotEmpty();
            RuleFor(x => x.RewinderOneTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneTensionAverage).NotEmpty();
            RuleFor(x => x.RewinderOneTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionMinimum).NotEmpty();
            RuleFor(x => x.RewinderTwoTensionMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionMaximum).NotEmpty();
            RuleFor(x => x.RewinderTwoTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAverage).NotEmpty();
            RuleFor(x => x.RewinderTwoTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.MachineMaximumSpeed).NotEmpty();
            RuleFor(x => x.MachineMaximumSpeed).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.MachineAverageSpeed).NotEmpty();
            RuleFor(x => x.MachineAverageSpeed).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.DownTimeDuration).NotEmpty();
            RuleFor(x => x.DownTimeDuration).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ScrapReasonOne).NotEmpty();
            RuleFor(x => x.ScrapReasonOne).Length(1, 200);

            RuleFor(x => x.ScrapValueOne).NotEmpty();
            RuleFor(x => x.ScrapValueOne).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.UnwinderThickness).NotEmpty();
            RuleFor(x => x.UnwinderThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValue).NotEmpty();
            RuleFor(x => x.UnwinderThicknessCalculatedValue).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMinumum).NotEmpty();
            RuleFor(x => x.UnwinderThicknessCalculatedValueMinumum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMaximum).NotEmpty();
            RuleFor(x => x.UnwinderThicknessCalculatedValueMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.TensionInletValueActuel).NotEmpty();
            RuleFor(x => x.TensionInletValueActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionInletValueMinimum).NotEmpty();
            RuleFor(x => x.TensionInletValueMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionInletValueMaximum).NotEmpty();
            RuleFor(x => x.TensionInletValueMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueMinimum).NotEmpty();
            RuleFor(x => x.TensionOutletValueMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueMaximum).NotEmpty();
            RuleFor(x => x.TensionOutletValueMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueAverage).NotEmpty();
            RuleFor(x => x.TensionOutletValueAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ContactRollTwoTwoDiameter).NotEmpty();
            RuleFor(x => x.ContactRollTwoTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ContactRollTwoThreeDiameter).NotEmpty();
            RuleFor(x => x.ContactRollTwoThreeDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.AccelerationTime).NotEmpty();
            RuleFor(x => x.AccelerationTime).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransportMachineRpmMaximum).NotEmpty();
            RuleFor(x => x.TransportMachineRpmMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransportMachineRpmAverage).NotEmpty();
            RuleFor(x => x.TransportMachineRpmAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionMinimum).NotEmpty();
            RuleFor(x => x.RewinderOneAbsoliteTensionMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionMaximum).NotEmpty();
            RuleFor(x => x.RewinderOneAbsoliteTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionAverage).NotEmpty();
            RuleFor(x => x.RewinderOneAbsoliteTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureActuelNewton).NotEmpty();
            RuleFor(x => x.RewinderOneContactPressureActuelNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMinimumlNewton).NotEmpty();
            RuleFor(x => x.RewinderOneContactPressureMinimumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMaximumlNewton).NotEmpty();
            RuleFor(x => x.RewinderOneContactPressureMaximumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureAverageNewton).NotEmpty();
            RuleFor(x => x.RewinderOneContactPressureAverageNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionActuel).NotEmpty();
            RuleFor(x => x.RewinderTwoAbsoliteTensionActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionMimimum).NotEmpty();
            RuleFor(x => x.RewinderTwoAbsoliteTensionMimimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionMaximum).NotEmpty();
            RuleFor(x => x.RewinderTwoAbsoliteTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionAverage).NotEmpty();
            RuleFor(x => x.RewinderTwoAbsoliteTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureActuelNewton).NotEmpty();
            RuleFor(x => x.RewinderTwoContactPressureActuelNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMinimumlNewton).NotEmpty();
            RuleFor(x => x.RewinderTwoContactPressureMinimumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMaximumlNewton).NotEmpty();
            RuleFor(x => x.RewinderTwoContactPressureMaximumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureAverageNewton).NotEmpty();
            RuleFor(x => x.RewinderTwoContactPressureAverageNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ContactRollOnePositionActual).NotEmpty();
            RuleFor(x => x.ContactRollOnePositionActual).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ContactRollTwoPositionActual).NotEmpty();
            RuleFor(x => x.ContactRollTwoPositionActual).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.RewinderOneSlittingWidthSported).NotEmpty();
            RuleFor(x => x.RewinderOneSlittingWidthSported).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoSlittingWidthSported).NotEmpty();
            RuleFor(x => x.RewinderTwoSlittingWidthSported).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PreCutterOneTwoOnOffStatus).NotEmpty();
            RuleFor(x => x.PreCutterOneTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterOnOffStatus).NotEmpty();
            RuleFor(x => x.BoosterOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.SuctionOnOffStatus).NotEmpty();
            RuleFor(x => x.SuctionOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortOneOnOffStatus).NotEmpty();
            RuleFor(x => x.BoosterSortOneOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortTwoOnOffStatus).NotEmpty();
            RuleFor(x => x.BoosterSortTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortThreeOnOffStatus).NotEmpty();
            RuleFor(x => x.BoosterSortThreeOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.AirFlapOneMinimum).NotEmpty();
            RuleFor(x => x.AirFlapOneMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapOneMaximum).NotEmpty();
            RuleFor(x => x.AirFlapOneMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapOneAverage).NotEmpty();
            RuleFor(x => x.AirFlapOneAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoActual).NotEmpty();
            RuleFor(x => x.AirFlapTwoActual).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoMinimum).NotEmpty();
            RuleFor(x => x.AirFlapTwoMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoMaximum).NotEmpty();
            RuleFor(x => x.AirFlapTwoMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoAverage).NotEmpty();
            RuleFor(x => x.AirFlapTwoAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthTwoOneOnOffStatus).NotEmpty();
            RuleFor(x => x.RollWidthTwoOneOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthTwoTwoOnOffStatus).NotEmpty();
            RuleFor(x => x.RollWidthTwoTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthFourOnOffStatus).NotEmpty();
            RuleFor(x => x.RollWidthFourOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthOneThreeSpeedMaximum).NotEmpty();
            RuleFor(x => x.RollWidthOneThreeSpeedMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneThreeSpeedAverage).NotEmpty();
            RuleFor(x => x.RollWidthOneThreeSpeedAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedMaximum).NotEmpty();
            RuleFor(x => x.RollWidthOneFourSpeedMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedAverage).NotEmpty();
            RuleFor(x => x.RollWidthOneFourSpeedAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
