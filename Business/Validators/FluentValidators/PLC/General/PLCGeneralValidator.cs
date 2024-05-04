using Entities.Concrete.Entities.PLC.General;
using Entities.Concrete.Enums.PLC.Machine;
using FluentValidation;


namespace Business.Validators.FluentValidators.PLC.Recipe
{
    public class PLCGeneralValidator : AbstractValidator<PLCGeneral>
    {
        public PLCGeneralValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.RecipeNameLast).Length(1, 40);//Name:RecipeNameLast,Adress:DB 90 DBB 40,Data Type:String

            RuleFor(x => x.MachineMode).IsInEnum();//Name:MachineMode,Adress:DB 90 DBW 24,Data Type:Int

            RuleFor(x => x.MachineState).IsInEnum();//Name:MachineMode,Adress:DB 90 DBW 26,Data Type:Int

            RuleFor(x => x.MachineSpeedSet).InclusiveBetween(short.MinValue, short.MaxValue);//Name:MachineSpeedSet,Adress:DB 91 DBW 2,Data Type:Int

            RuleFor(x => x.MachineSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);//Name:MachineSpeedAct,Adress:DB 90 DBW 2,Data Type:Int

            RuleFor(x => x.MachineSpeedMaximum).InclusiveBetween(short.MinValue, short.MaxValue);//Name:MachineSpeedMax,Adress:DB 90 DBW 0,Data Type:Int

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}