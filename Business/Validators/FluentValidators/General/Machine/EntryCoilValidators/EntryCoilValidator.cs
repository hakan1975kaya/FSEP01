using Entities.Concrete.Entities.General.Machine;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.EntryCoilValidators
{
    public class EntryCoilValidator:AbstractValidator<EntryCoil>
    {
        public EntryCoilValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Alloy).Length(1, 20);

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.EntryThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Temper).Length(1, 20);

            RuleFor(x => x.ProdGroup).Length(1, 200);

            RuleFor(x => x.EntryCoilInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilWeight).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryCoilLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.EntryOuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PostedId).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.LastProductionTime).InclusiveBetween(DateTime.MinValue,DateTime.MaxValue);

            RuleFor(x => x.PreviousPositionSteps).Length(1, 20);

            RuleFor(x => x.BlockedFlag).Length(1, 10);

            RuleFor(x => x.CoilOuterDiameterMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilOuterDiameterMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilWeightMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilWeightMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthAim).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.WidthToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PositionStepId).Length(1, 40);

            RuleFor(x => x.MainCoilProductionId).Length(1, 40);

            RuleFor(x => x.PositionStepSequenceNumber).Length(1, 40);

            RuleFor(x => x.PositionStepType).IsInEnum();

            RuleFor(x => x.TerstenActivate).Length(1, 50);

            RuleFor(x => x.CustomerName).Length(1, 100);

            RuleFor(x => x.ProductionGroup).Length(1, 30);

            RuleFor(x => x.ThicknessAim).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SoiThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessToleranceMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SurfaceCondition).Length(1, 30);

            RuleFor(x => x.SpoolProtrusion).Length(1, 20);

            RuleFor(x => x.EntrySpoolType).IsInEnum();

            RuleFor(x => x.ExitSpoolInnerDiameter).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ExitSpoolType).IsInEnum();

            RuleFor(x => x.LengthInMeters).InclusiveBetween(long.MinValue, long.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LengthInMetersToleranceMinimum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.FoilAverageThicknessTolerance).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.NumberOfSplicesPerCoilMaximum).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TargendDate).InclusiveBetween(DateTime.MinValue, DateTime.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
