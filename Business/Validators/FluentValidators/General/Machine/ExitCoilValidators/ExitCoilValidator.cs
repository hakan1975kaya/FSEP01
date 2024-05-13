using Entities.Concrete.Entities.General.Machine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.ExitCoilValidators
{
    public class ExitCoilValidator:AbstractValidator<ExitCoil>
    {
        public ExitCoilValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.EntryCoilId).NotEmpty();

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.ProductionStart).InclusiveBetween(DateTime.MinValue, DateTime.MaxValue);

            RuleFor(x => x.ProductionEnd).InclusiveBetween(DateTime.MinValue, DateTime.MaxValue);

            RuleFor(x => x.FlagConsumed).Length(1,1);

            RuleFor(x => x.OuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ExitCoilLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ExitInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SpoolType).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionerBottom).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.TensionerTop).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ThicknessInspectionTop).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessInspectionBottom).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WindingSenseExitOne).Length(1, 50);

            RuleFor(x => x.WindingSenseExitTwo).Length(1, 50);

            RuleFor(x => x.WindingSenseEntry).Length(1, 50);

            RuleFor(x => x.SlitBaseNumber).Length(1, 60);

            RuleFor(x => x.OperatorName).Length(1, 60);

            RuleFor(x => x.TransporterOneMinimumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterOneMaximumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterOneAverageTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoMinimumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoMaximumTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransporterTwoAverageTension).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ThicknessInspectionBottom).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneMaximumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WorkRollTopDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMaximumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.MachineMaximumSpeed).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.MachineAverageSpeed).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.DownTimeDuration).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.SpoolType).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.SpoolType).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.SpoolType).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.SpoolType).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ScrapReasonOne).Length(1, 60);

            RuleFor(x => x.ScrapValueOne).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.UnwinderThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValue).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMinumum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.TensionInletValueActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionInletValueMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionInletValueMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionOutletValueAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ContactRollTwoTwoDiameter).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ContactRollTwoThreeDiameter).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.AccelerationTime).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransportMachineRpmMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransportMachineRpmAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneAbsoliteTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureActuelNewton).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMinimumlNewton).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMaximumlNewton).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureAverageNewton).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionMimimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoAbsoliteTensionAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureActuelNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMinimumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMaximumlNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureAverageNewton).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ContactRollOnePositionActual).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.ContactRollTwoPositionActual).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.RewinderOneSlittingWidthSported).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoSlittingWidthSported).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PreCutterOneTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.SuctionOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortOneOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortThreeOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.AirFlapOneMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapOneMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapOneAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoActual).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.AirFlapTwoAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthTwoOneOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthTwoTwoOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthFourOnOffStatus).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthOneThreeSpeedMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneThreeSpeedAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedAverage).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}