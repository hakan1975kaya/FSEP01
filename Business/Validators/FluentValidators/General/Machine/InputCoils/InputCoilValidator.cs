using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class InputCoilValidator : AbstractValidator<InputCoil>
    {
        public InputCoilValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.RecipeNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LocalId).Length(2, 20);

            RuleFor(x => x.CoilStatusNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilStatus).Length(2, 10);

            RuleFor(x => x.Alloy).Length(2, 10);

            RuleFor(x => x.Thickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Width).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Weight).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Length).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.InnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Temper).Length(2, 10);

            RuleFor(x => x.UsageArea).Length(2, 15);

            RuleFor(x => x.SetupGenerateStatusNumber).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SetupGenerateStatusDescription).Length(2, 400);

            RuleFor(x => x.Gravity).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MainCoilProductionId).Length(2, 15);

            RuleFor(x => x.SurfaceCondition).Length(2, 15);

            RuleFor(x => x.Location).Length(2, 15);

            RuleFor(x => x.DeadLine).InclusiveBetween(DateTime.MinValue, DateTime.MaxValue);

            RuleFor(x => x.BlockedFlag).Length(2, 5);

            RuleFor(x => x.TerstenAc).Length(2, 5);

            RuleFor(x => x.PreviousPositionSteps).Length(2, 10);

            RuleFor(x => x.NextPositionSteps).Length(2, 10);

            RuleFor(x => x.LastProductionTime).InclusiveBetween(DateTime.MinValue, DateTime.MaxValue);

            RuleFor(x => x.Comment).Length(2, 100);

            RuleFor(x => x.ProductionRemark).Length(2, 100);

            RuleFor(x => x.ExitSpoolInnerDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ExitSpoolType).Length(2, 20);

            RuleFor(x => x.SpoolProtrusion).Length(2, 10);

            RuleFor(x => x.BurrHeight).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilWeightMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilWeightMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EdgeWaveHeightMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.FoilAvgerageThicknessTolerance).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.LengthInMeters).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.NumberOfEdgeWavePerMeter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.NumberOfSplicesPerCoilMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PackageCode).Length(2, 15);

            RuleFor(x => x.MinimumAmountOfLubrication).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MaximumAmountOfLubrication).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SOIThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessAim).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumOuterDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MaximumOuterDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.WidthAim).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.WidthToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CustomerName).Length(2, 50);

            RuleFor(x => x.ReSendSetupToleranceOne).InclusiveBetween(false, true);

            RuleFor(x => x.RemainingWeight).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
