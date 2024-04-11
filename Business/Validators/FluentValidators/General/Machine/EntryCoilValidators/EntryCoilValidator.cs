using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.EntryCoilValidators
{
    public class EntryCoilValidator : AbstractValidator<EntryCoil>
    {
        public EntryCoilValidator()
        {
            RuleFor(x => x.Alloy).NotEmpty();
            RuleFor(x => x.Alloy).Length(1, 20);

            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.EntryThickness).NotEmpty();
            RuleFor(x => x.EntryThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Temper).NotEmpty();
            RuleFor(x => x.Temper).Length(1, 20);

            RuleFor(x => x.ProdGroup).NotEmpty();
            RuleFor(x => x.ProdGroup).Length(1, 60);

            RuleFor(x => x.EntryCoilInnerDiameter).NotEmpty();
            RuleFor(x => x.EntryCoilInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilWidth).NotEmpty();
            RuleFor(x => x.EntryCoilWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilWeight).NotEmpty();
            RuleFor(x => x.EntryCoilWeight).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilLength).NotEmpty();
            RuleFor(x => x.EntryCoilLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryInnerDiameter).NotEmpty();
            RuleFor(x => x.EntryInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryOuterDiameter).NotEmpty();
            RuleFor(x => x.EntryOuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PostedId).NotEmpty();
            RuleFor(x => x.PostedId).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.LastProductionTime).NotEmpty();
            RuleFor(x => x.LastProductionTime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.PreviousPositionSteps).NotEmpty();
            RuleFor(x => x.PreviousPositionSteps).Length(1, 20);

            RuleFor(x => x.BlockedFlag).NotEmpty();
            RuleFor(x => x.BlockedFlag).Length(1, 10);

            RuleFor(x => x.PostedId).NotEmpty();
            RuleFor(x => x.PostedId).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilOuterDiameterMinimum).NotEmpty();
            RuleFor(x => x.CoilOuterDiameterMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilOuterDiameterMaximum).NotEmpty();
            RuleFor(x => x.CoilOuterDiameterMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilWeightMinimum).NotEmpty();
            RuleFor(x => x.CoilWeightMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilWeightMaximum).NotEmpty();
            RuleFor(x => x.CoilWeightMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthAim).NotEmpty();
            RuleFor(x => x.WidthAim).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.WidthToleranceMinimum).NotEmpty();
            RuleFor(x => x.WidthToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthToleranceMaximum).NotEmpty();
            RuleFor(x => x.WidthToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PositionStepId).NotEmpty();
            RuleFor(x => x.PositionStepId).Length(1, 20);

            RuleFor(x => x.PositionStepId).NotEmpty();
            RuleFor(x => x.PositionStepId).Length(1, 40);

            RuleFor(x => x.PositionStepSequenceNumber).NotEmpty();
            RuleFor(x => x.PositionStepSequenceNumber).Length(1, 20);

            RuleFor(x => x.PositionStepType).NotEmpty();
            RuleFor(x => x.PositionStepType).Length(1, 10);

            RuleFor(x => x.TerstenActivate).NotEmpty();
            RuleFor(x => x.TerstenActivate).Length(1, 10);

            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.CustomerName).Length(1, 100);

            RuleFor(x => x.ProductionGroup).NotEmpty();
            RuleFor(x => x.ProductionGroup).Length(1, 60);

            RuleFor(x => x.ThickbessAim).NotEmpty();
            RuleFor(x => x.ThickbessAim).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SoiThickness).NotEmpty();
            RuleFor(x => x.SoiThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMinimum).NotEmpty();
            RuleFor(x => x.ThicknessToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMaximum).NotEmpty();
            RuleFor(x => x.ThicknessToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SurfaceCondition).NotEmpty();
            RuleFor(x => x.SurfaceCondition).Length(1, 30);

            RuleFor(x => x.SpoolProtrusion).NotEmpty();
            RuleFor(x => x.SpoolProtrusion).Length(1, 20);

            RuleFor(x => x.EntrySpoolType).NotEmpty();
            RuleFor(x => x.EntrySpoolType).Length(1, 40);

            RuleFor(x => x.ExitSpoolInnerDiameter).NotEmpty();
            RuleFor(x => x.ExitSpoolInnerDiameter).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ExitSpoolType).NotEmpty();
            RuleFor(x => x.ExitSpoolType).Length(1, 40);

            RuleFor(x => x.LengthInMeters).NotEmpty();
            RuleFor(x => x.LengthInMeters).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMaximum).NotEmpty();
            RuleFor(x => x.LengthInMetersToleranceMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMinimum).NotEmpty();
            RuleFor(x => x.LengthInMetersToleranceMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.FoilAverageThicknessTolerance).NotEmpty();
            RuleFor(x => x.FoilAverageThicknessTolerance).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.NumberOfSplicesPerCoilMaximum).NotEmpty();
            RuleFor(x => x.NumberOfSplicesPerCoilMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TargendDate).NotEmpty();
            RuleFor(x => x.TargendDate).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
