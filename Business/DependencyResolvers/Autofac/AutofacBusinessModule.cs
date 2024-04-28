using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract.General.General;
using Business.Abstract.PLC.InputCoils;
using Business.Abstract.PSI.Telegrams;
using Business.Abstract.PSI.Transfers;
using Business.Abstract.PSI.Types;
using Business.Concrete.General.General;
using Business.Concrete.PLC.InputCoils;
using Business.Concrete.PSI.Telegrams;
using Business.Concrete.PSI.Transfers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Concrete.Jwt;
using DataAccess.Abstract.General.General;
using DataAccess.Abstract.General.Machine.General;
using DataAccess.Abstract.General.Machine.InputCoils;
using DataAccess.Abstract.General.Machine.OutputCoils;
using DataAccess.Abstract.General.Machine.Parameters;
using DataAccess.Abstract.General.Machine.ProcessCoils;
using DataAccess.Abstract.General.Machine.Recipes;
using DataAccess.Abstract.PSI.Telegrams;
using DataAccess.Abstract.PSI.Types;
using DataAccess.Concrete.EntityFramework.General.General;
using DataAccess.Concrete.EntityFramework.General.Machine.General;
using DataAccess.Concrete.EntityFramework.General.Machine.InputCoils;
using DataAccess.Concrete.EntityFramework.General.Machine.OutputCoils;
using DataAccess.Concrete.EntityFramework.General.Machine.Parameters;
using DataAccess.Concrete.EntityFramework.General.Machine.ProcessCoils;
using DataAccess.Concrete.EntityFramework.General.Machine.Recipes;
using DataAccess.Concrete.EntityFramework.PSI.Telegrams;
using DataAccess.Concrete.EntityFramework.PSI.Types;
using PLC.Abstract;
using PLC.Concrete;
using PLC.Helper.Abstract;
using PLC.Helper.Concrete;
using System.Diagnostics;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //General
            //General
            builder.RegisterType<EFDemandDal>().As<IDemandDal>();
            builder.RegisterType<DemandManager>().As<IDemandService>();

            builder.RegisterType<EFUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
   
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<EFMenuDal>().As<IMenuDal>();
            builder.RegisterType<MenuManager>().As<IMenuService>();

            builder.RegisterType<EFRoleDal>().As<IRoleDal>();
            builder.RegisterType<RoleManager>().As<IRoleService>();

            builder.RegisterType<EFRoleDemandDal>().As<IRoleDemandDal>();
            builder.RegisterType<RoleDemandManager>().As<IRoleDemandService>();

            builder.RegisterType<EFRoleMenuDal>().As<IRoleMenuDal>();
            builder.RegisterType<RoleMenuManager>().As<IRoleMenuService>();

            builder.RegisterType<EFUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EFUserRoleDal>().As<IUserRoleDal>();
            builder.RegisterType<UserRoleManager>().As<IUserRoleService>();

            builder.RegisterType<EFApiLogDal>().As<IApiLogDal>();
            builder.RegisterType<ApiLogManager>().As<IApiLogService>();

            builder.RegisterType<EFWebLogDal>().As<IWebLogDal>();
            builder.RegisterType<WebLogManager>().As<IWebLogService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<Stopwatch>();

            //General
            //Machine
            //General
            builder.RegisterType<EFContactRollDal>().As<IContactRollDal>();
            builder.RegisterType<ContactRollManager>().As<IContactRollService>();

            builder.RegisterType<EFDefinationDal>().As<IDefinationDal>();
            builder.RegisterType<DefinationManager>().As<IDefinationService>();

            builder.RegisterType<EFDensityDal>().As<IDensityDal>();
            builder.RegisterType<DensityManager>().As<IDensityService>();

            builder.RegisterType<EFEventDal>().As<IEventDal>();
            builder.RegisterType<EventManager>().As<IEventService>();

            builder.RegisterType<EFHeadTailScrapDal>().As<IHeadTailScrapDal>();
            builder.RegisterType<HeadTailScrapManager>().As<IHeadTailScrapService>();

            builder.RegisterType<EFLevelOneTelegramDal>().As<ILevelOneTelegramDal>();
            builder.RegisterType<LevelOneTelegramManager>().As<ILevelOneTelegramService>();

            builder.RegisterType<EFLevelThreeTelegramDal>().As<ILevelThreeTelegramDal>();
            builder.RegisterType<LevelThreeTelegramManager>().As<ILevelThreeTelegramService>();

            builder.RegisterType<EFLubracationRollDal>().As<ILubracationRollDal>();
            builder.RegisterType<LubracationRollManager>().As<ILubracationRollService>();

            builder.RegisterType<EFSlitPatternDal>().As<ISlitPatternDal>();
            builder.RegisterType<SlitPatternManager>().As<ISlitPatternService>();

            builder.RegisterType<EFSlitPatternDetailDal>().As<ISlitPatternDetailDal>();
            builder.RegisterType<SlitPatternDetailManager>().As<ISlitPatternDetailService>();

            builder.RegisterType<EFTramRollDal>().As<ITramRollDal>();
            builder.RegisterType<TramRollManager>().As<ITramRollService>();

            builder.RegisterType<EFUsageAreaDal>().As<IUsageAreaDal>();
            builder.RegisterType<UsageAreaManager>().As<IUsageAreaService>();
            //General
            //Machine
            //InputCoilS
            builder.RegisterType<EFInputCoilAttachmentDal>().As<IInputCoilAttachmentDal>();
            builder.RegisterType<InputCoilAttachmentManager>().As<IInputCoilAttachmentService>();

            builder.RegisterType<EFInputCoilDal>().As<IInputCoilDal>();
            builder.RegisterType<InputCoilManager>().As<IInputCoilService>();

            builder.RegisterType<EFInputCoilDefectDal>().As<IInputCoilDefectDal>();
            builder.RegisterType<InputCoilDefectManager>().As<IInputCoilDefectService>();

            builder.RegisterType<EFInputCoilRemarkDal>().As<IInputCoilRemarkDal>();
            builder.RegisterType<InputCoilRemarkManager>().As<IInputCoilRemarkService>();
            //General
            //Machine
            //OutputCoilS
            builder.RegisterType<EFOutputCoilDal>().As<IOutputCoilDal>();
            builder.RegisterType<OutputCoilManager>().As<IOutputCoilService>();

            builder.RegisterType<EFOutputCoilOtherDal>().As<IOutputCoilOtherDal>();
            builder.RegisterType<OutputCoilOtherManager>().As<IOutputCoilOtherService>();
            //General
            //Machine
            //Parameters
            builder.RegisterType<EFParameterApplyingUnitDal>().As<IParameterApplyingUnitDal>();
            builder.RegisterType<ParameterApplyingUnitManager>().As<IParameterApplyingUnitService>();

            builder.RegisterType<EFParameterBasicDataDal>().As<IParameterBasicDataDal>();
            builder.RegisterType<ParameterBasicDataManager>().As<IParameterBasicDataService>();

            builder.RegisterType<EFParameterDal>().As<IParameterDal>();
            builder.RegisterType<ParameterManager>().As<IParameterService>();

            builder.RegisterType<EFParameterMachineDal>().As<IParameterMachineDal>();
            builder.RegisterType<ParameterMachineManager>().As<IParameterMachineService>();

            builder.RegisterType<EFParameterRewinderDal>().As<IParameterRewinderDal>();
            builder.RegisterType<ParameterRewinderManager>().As<IParameterRewinderService>();

            builder.RegisterType<EFParameterRewinderOnePressureDal>().As<IParameterRewinderOnePressureDal>();
            builder.RegisterType<ParameterRewinderOnePressureManager>().As<IParameterRewinderOnePressureService>();

            builder.RegisterType<EFParameterRewinderOneTensionDal>().As<IParameterRewinderOneTensionDal>();
            builder.RegisterType<ParameterRewinderOneTensionManager>().As<IParameterRewinderOneTensionService>();

            builder.RegisterType<EFParameterRewinderTwoPressureDal>().As<IParameterRewinderTwoPressureDal>();
            builder.RegisterType<ParameterRewinderTwoPressureManager>().As<IParameterRewinderTwoPressureService>();

            builder.RegisterType<EFParameterRewinderTwoTensionDal>().As<IParameterRewinderTwoTensionDal>();
            builder.RegisterType<ParameterRewinderTwoTensionManager>().As<IParameterRewinderTwoTensionService>();

            builder.RegisterType<EFParameterSpeedCharacteristicDal>().As<IParameterSpeedCharacteristicDal>();
            builder.RegisterType<ParameterSpeedCharacteristicManager>().As<IParameterSpeedCharacteristicService>();

            builder.RegisterType<EFParameterSuctionDal>().As<IParameterSuctionDal>();
            builder.RegisterType<ParameterSuctionManager>().As<IParameterSuctionService>();

            //General
            //Machine
            //Parameters
            builder.RegisterType<EFProcessCoilDal>().As<IProcessCoilDal>();
            builder.RegisterType<ProcessCoilManager>().As<IProcessCoilService>();

            //General
            //Machine
            //Recipes
            builder.RegisterType<EFRecipeApplyingUnitDal>().As<IRecipeApplyingUnitDal>();
            builder.RegisterType<RecipeApplyingUnitManager>().As<IRecipeApplyingUnitService>();

            builder.RegisterType<EFRecipeBasicDataDal>().As<IRecipeBasicDataDal>();
            builder.RegisterType<RecipeBasicDataManager>().As<IRecipeBasicDataService>();

            builder.RegisterType<EFRecipeMachineDal>().As<IRecipeMachineDal>();
            builder.RegisterType<RecipeMachineManager>().As<IRecipeMachineService>();

            builder.RegisterType<EFRecipeRewinderDal>().As<IRecipeRewinderDal>();
            builder.RegisterType<RecipeRewinderManager>().As<IRecipeRewinderService>();

            builder.RegisterType<EFRecipeRewinderOnePressureDal>().As<IRecipeRewinderOnePressureDal>();
            builder.RegisterType<RecipeRewinderOnePressureManager>().As<IRecipeRewinderOnePressureService>();

            builder.RegisterType<EFRecipeRewinderOneTensionDal>().As<IRecipeRewinderOneTensionDal>();
            builder.RegisterType<RecipeRewinderOneTensionManager>().As<IRecipeRewinderOneTensionService>();

            builder.RegisterType<EFRecipeRewinderTwoPressureDal>().As<IRecipeRewinderTwoPressureDal>();
            builder.RegisterType<RecipeRewinderTwoPressureManager>().As<IRecipeRewinderTwoPressureService>();

            builder.RegisterType<EFRecipeRewinderTwoTensionDal>().As<IRecipeRewinderTwoTensionDal>();
            builder.RegisterType<RecipeRewinderTwoTensionManager>().As<IRecipeRewinderTwoTensionService>();

            builder.RegisterType<EFRecipeSpeedCharacteristicDal>().As<IRecipeSpeedCharacteristicDal>();
            builder.RegisterType<RecipeSpeedCharacteristicManager>().As<IRecipeSpeedCharacteristicService>();

            builder.RegisterType<EFRecipeSuctionDal>().As<IRecipeSuctionDal>();
            builder.RegisterType<RecipeSuctionManager>().As<IRecipeSuctionService>();

            //PLC
            builder.RegisterType<PLCHelper>().As<IPLCHelper>();
            builder.RegisterType<PLCDal>().As<IPLCDal>();
            builder.RegisterType<PLCInputCoilManager>().As<IPLCInputCoilService>();

            //PSI
            //Telegrams
            builder.RegisterType<EFPSIGeneralAckPES2L2Dal>().As<IPSIGeneralAckPES2L2Dal>();
            builder.RegisterType<PSIGeneralAckPES2L2Manager>().As<IPSIGeneralAckPES2L2Service>();

            builder.RegisterType<EFPSIPingAckL22PESDal>().As<IPSIPingAckL22PESDal>();
            builder.RegisterType<PSIPingAckL22PESManager>().As<IPSIPingAckL22PESService>();

            builder.RegisterType<EFPSIPingAckPES2L2Dal>().As<IPSIPingAckPES2L2Dal>();
            builder.RegisterType<PSIPingAckPES2L2Manager>().As<IPSIPingAckPES2L2Service>();

            builder.RegisterType<EFPSIPingL22PESDal>().As<IPSIPingL22PESDal>();
            builder.RegisterType<PSIPingL22PESManager>().As<IPSIPingL22PESService>();

            builder.RegisterType<EFPSIPingPES2L2Dal>().As<IPSIPingPES2L2Dal>();
            builder.RegisterType<PSIPingPES2L2Manager>().As<IPSIPingPES2L2Service>();

            builder.RegisterType<EFPSIProcessDataPES2L2Dal>().As<IPSIProcessDataPES2L2Dal>();
            builder.RegisterType<PSIProcessDataPES2L2Manager>().As<IPSIProcessDataPES2L2Service>();

            builder.RegisterType<EFPSIProcessStateL22PESDal>().As<IPSIProcessStateL22PESDal>();
            builder.RegisterType<PSIProcessStateL22PESManager>().As<IPSIProcessStateL22PESService>();

            builder.RegisterType<EFPSIProdReportL22PESDal>().As<IPSIProdReportL22PESDal>();
            builder.RegisterType<PSIProdReportL22PESManager>().As<IPSIProdReportL22PESService>();

            builder.RegisterType<EFPSIRequestProcessDataL22PESDal>().As<IPSIRequestProcessDataL22PESDal>();
            builder.RegisterType<PSIRequestProcessDataL22PESManager>().As<IPSIRequestProcessDataL22PESService>();

            //PSI
            //Transfers
            builder.RegisterType<PSIManager>().As<IPSIService>();

            //PSI
            //Types
            builder.RegisterType<EFPSITypeDefectActionListDal>().As<IPSITypeDefectActionListDal>();
            builder.RegisterType<PSITypeDefectActionListManager>().As<IPSITypeDefectActionListService>();

            builder.RegisterType<EFPSITypeDefectListDal>().As<IPSITypeDefectListDal>();
            builder.RegisterType<PSITypeDefectListManager>().As<IPSITypeDefectListService>();

            builder.RegisterType<EFPSITypeHeaderDal>().As<IPSITypeHeaderDal>();
            builder.RegisterType<PSITypeHeaderManager>().As<IPSITypeHeaderService>();

            builder.RegisterType<EFPSITypeInputMatCoordDal>().As<IPSITypeInputMatCoordDal>();
            builder.RegisterType<PSITypeInputMatCoordManager>().As<IPSITypeInputMatCoordService>();

            builder.RegisterType<EFPSITypeInputMatDal>().As<IPSITypeInputMatDal>();
            builder.RegisterType<PSITypeInputMatManager>().As<IPSITypeInputMatService>();

            builder.RegisterType<EFPSITypeMatIdDal>().As<IPSITypeMatIdDal>();
            builder.RegisterType<PSITypeMatIdManager>().As<IPSITypeMatIdService>();

            builder.RegisterType<EFPSITypeOutputMatDal>().As<IPSITypeOutputMatDal>();
            builder.RegisterType<PSITypeOutputMatManager>().As<IPSITypeOutputMatService>();

            builder.RegisterType<EFPSITypeOutputMatTargetDal>().As<IPSITypeOutputMatTargetDal>();
            builder.RegisterType<PSITypeOutputMatTargetManager>().As<IPSITypeOutputMatTargetService>();

            builder.RegisterType<EFPSITypeParameterListDal>().As<IPSITypeParameterListDal>();
            builder.RegisterType<PSITypeParameterListManager>().As<IPSITypeParameterListService>();

            builder.RegisterType<EFPSITypeProcessDal>().As<IPSITypeProcessDal>();
            builder.RegisterType<PSITypeProcessManager>().As<IPSITypeProcessService>();

            builder.RegisterType<EFPSITypeProcessInstructionsDal>().As<IPSITypeProcessInstructionsDal>();
            builder.RegisterType<PSITypeProcessInstructionsManager>().As<IPSITypeProcessInstructionsService>();

            builder.RegisterType<EFPSITypeTimeStampDal>().As<IPSITypeTimeStampDal>();
            builder.RegisterType<PSITypeTimeStampManager>().As<IPSITypeTimeStampService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
