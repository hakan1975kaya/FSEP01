using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class OutputCoilValidator : AbstractValidator<OutputCoil>
    {
        public OutputCoilValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.CoilIdOutput).Length(2, 20);

            RuleFor(x => x.CoilIdInput).Length(2, 20);

            RuleFor(x => x.CoilStatusNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.CoilStatus).Length(2, 10);

            RuleFor(x => x.CustomerName).Length(2, 50);

            RuleFor(x => x.CoilLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CoilInnerDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.SpoolType).Length(2, 40);

            RuleFor(x => x.TensionerBottom).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TensionTop).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ThicknessInspectionTop).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.ThicknessInspectionBottom).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.WindingSenseEntry).Length(2, 10);

            RuleFor(x => x.WindingSenseExitOne).Length(2, 10);

            RuleFor(x => x.WindingSenseExitTwo).Length(2, 50);

            RuleFor(x => x.SlitNumber).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SlitBaseNumber).Length(2, 30);

            RuleFor(x => x.OperatorName).Length(2, 20);

            RuleFor(x => x.ScrapReasonOne).Length(2, 30);

            RuleFor(x => x.ScrapValueOne).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ScrapReasonTwo).Length(2, 30);

            RuleFor(x => x.ScrapValueTwo).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ScrapReasonThree).Length(2, 30);

            RuleFor(x => x.ScrapValueThree).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ScrapReasonFour).Length(2, 30);

            RuleFor(x => x.ScrapValueFour).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ScrapReasonFive).Length(2, 30);

            RuleFor(x => x.ScrapValueFive).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.ProductionStart).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ProductionEnd).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Remark).Length(2, 125);

            RuleFor(x => x.FlagConsumed).Length(2, 10);

            RuleFor(x => x.TransportOneTensionActive).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportOneTensionMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportOneTensionMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportOneTensionAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTensionActive).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTensionMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTensionMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTensionAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActiveTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneMinimumTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneMaximumTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneAverageTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActiveContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneMaximumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoActiveTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoMinimumTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoMaximumTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoAverageTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoActiveContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMinimumContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoMaximumContacPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoAverageContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MachineMinimumSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MachineMaximumSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MachineAverageSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ProductionDuration).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.DownTimeDuration).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.FileName).Length(2, 100);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
