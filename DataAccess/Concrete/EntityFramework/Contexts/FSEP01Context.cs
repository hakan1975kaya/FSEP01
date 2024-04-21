using Core.Entities.Concrete;
using Core.Utilities.Service;
using Entities.Concrete.Entities.General.General;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
using Entities.Concrete.Entities.General.Machine.Parameters;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;
using Entities.Concrete.Entities.General.Machine.Recipes;
using Entities.Concrete.Entities.PSI.Telegrams;
using Entities.Concrete.Entities.PSI.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class FSEP01Context : DbContext
    {
        private IConfiguration _configuration;
        public FSEP01Context()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FSEP01"));
        }
        //General
        //General
        public DbSet<Demand> Demands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleDemand> RoleDemands { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        //General
        //Machine
        //General
        public DbSet<ContactRoll> ContactRollS { get; set; }
        public DbSet<Defination> Definations { get; set; }
        public DbSet<Density> Densitys { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<HeadTailScrap> HeadTailScraps { get; set; }
        public DbSet<LevelOneTelegram> LevelOneTelegrms { get; set; }
        public DbSet<LevelThreeTelegram> LevelThreeTelegrams { get; set; }
        public DbSet<LubracationRoll> LubracationRolls { get; set; }
        public DbSet<SlitPattern> SlitPatterns { get; set; }
        public DbSet<SlitPatternDetail> SlitPatternDetails { get; set; }
        public DbSet<TramRoll> TramRolls { get; set; }
        public DbSet<UsageArea> UsageArea { get; set; }

        //General
        //Machine
        //InputCoils
        public DbSet<InputCoil> InputCoils { get; set; }
        public DbSet<InputCoilAttachment> InputCoilAttachments { get; set; }
        public DbSet<InputCoilDefect> InputCoilDefects { get; set; }
        public DbSet<InputCoilRemark> InputCoilRemarks { get; set; }

        //General
        //Machine
        //OutputCoils
        public DbSet<OutputCoil> OutputCoils { get; set; }
        public DbSet<OutputCoilOther> OutputCoilOthers { get; set; }

        //General
        //Machine
        //Parameters
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterApplyingUnit> ParameterApplyingUnits { get; set; }
        public DbSet<ParameterBasicData> ParameterBasicDatas { get; set; }
        public DbSet<ParameterMachine> ParameterMachines { get; set; }
        public DbSet<ParameterRewinder> ParameterRewinders { get; set; }
        public DbSet<ParameterRewinderOnePressure> ParameterRewinderOnePressures { get; set; }
        public DbSet<ParameterRewinderOneTension> ParameterRewinderOneTensions { get; set; }
        public DbSet<ParameterRewinderTwoPressure> ParameterRewinderTwoPressures { get; set; }
        public DbSet<ParameterRewinderTwoTension> ParameterRewinderTwoTensions { get; set; }
        public DbSet<ParameterSpeedCharacteristic> ParameterSpeedCharacteristics { get; set; }
        public DbSet<ParameterSuction> ParameterSuctions { get; set; }

        //General
        //Machine
        //ProcessCoils
        public DbSet<ProcessCoil> ProcessCoils { get; set; }

        //General
        //Machine
        //Recipes
        public DbSet<RecipeApplyingUnit> RecipeApplyingunits { get; set; }
        public DbSet<RecipeBasicData> RecipeBasicDatas { get; set; }
        public DbSet<RecipeMachine> RecipeMachines { get; set; }
        public DbSet<RecipeRewinder> RecipeRewinders { get; set; }
        public DbSet<RecipeRewinderOnePressure> RecipeRewinderOnePressures { get; set; }
        public DbSet<RecipeRewinderOneTension> RecipeRewinderOneTensions { get; set; }
        public DbSet<RecipeRewinderTwoPressure> RecipeRewinderTwoPressures { get; set; }
        public DbSet<RecipeRewinderTwoTension> PrRecipeRewinderTwoTensionsocessCoils { get; set; }
        public DbSet<RecipeSpeedCharacteristic> RecipeSpeedCharacteristics { get; set; }
        public DbSet<RecipeSuction> RecipeSuctions { get; set; }

        //PSI
        //Telegrams
        public DbSet<PSIGeneralAckPES2L2> GeneralAckPES2L2s { get; set; }
        public DbSet<PSIPingAckL22PES> PingAckL22PESs { get; set; }
        public DbSet<PSIPingAckPES2L2> PingAckPES2L2s { get; set; }
        public DbSet<PSIPingL22PES> PingL22PESs { get; set; }
        public DbSet<PSIPingPES2L2> PingPES2L2s { get; set; }
        public DbSet<PSIProcessDataPES2L2> ProcessDataPES2L2s { get; set; }
        public DbSet<PSIProcessStateL22PES> ProcessStateL22PESs { get; set; }
        public DbSet<PSIProdReportL22PES> ProdReportL22PESs { get; set; }
        public DbSet<PSIRequestProcessDataL22PES> RequestProcessDataL22PESs { get; set; }

        //PSI
        //Types
        public DbSet<PSITypeDefectActionList> TypeDefectActionLists { get; set; }
        public DbSet<PSITypeDefectList> TypeDefectLists { get; set; }
        public DbSet<PSITypeHeader> TypeHeaders { get; set; }
        public DbSet<PSITypeInputMat> TypeInputMats { get; set; }
        public DbSet<PSITypeInputMatCoord> TypeInputMatCoords { get; set; }
        public DbSet<PSITypeMatId> TypeMatIds { get; set; }
        public DbSet<PSITypeOutputMat> TypeOutputMats { get; set; }
        public DbSet<PSITypeOutputMatTarget> TypeOutputMatTargets { get; set; }
        public DbSet<PSITypeParameterList> TypeParameterLists { get; set; }
        public DbSet<PSITypeProcess> TypeProcesss { get; set; }
        public DbSet<PSITypeProcessInstructions> TypeProcessInstructionss { get; set; }
        public DbSet<PSITypeTimeStamp> TypeTimeStamps { get; set; }


    }
}
