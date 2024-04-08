using Core.Entities.Concrete;
using Core.Utilities.Service;
using Entities.Concrete.Entities.General.General;
using Entities.Concrete.Entities.General.Machine;
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
        public DbSet<Demand> Demands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleDemand> RoleDemands { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        //Telegrams
        public DbSet<GeneralAckPES2L2> GeneralAckPES2L2s { get; set; }
        public DbSet<PingAckL22PES> PingAckL22PESs { get; set; }
        public DbSet<PingAckPES2L2> PingAckPES2L2s { get; set; }
        public DbSet<PingL22PES> PingL22PESs { get; set; }
        public DbSet<PingPES2L2> PingPES2L2s { get; set; }
        public DbSet<ProcessDataPES2L2> ProcessDataPES2L2s { get; set; }
        public DbSet<ProcessStateL22PES> ProcessStateL22PESs { get; set; }
        public DbSet<ProdReportL22PES> ProdReportL22PESs { get; set; }
        public DbSet<RequestProcessDataL22PES> RequestProcessDataL22PESs { get; set; }

        //Types
        public DbSet<TypeDefectActionList> TypeDefectActionLists { get; set; }
        public DbSet<TypeDefectList> TypeDefectLists { get; set; }
        public DbSet<TypeHeader> TypeHeaders { get; set; }
        public DbSet<TypeInputMat> TypeInputMats { get; set; }
        public DbSet<TypeInputMatCoord> TypeInputMatCoords { get; set; }
        public DbSet<TypeMatId> TypeMatIds { get; set; }
        public DbSet<TypeOutputMat> TypeOutputMats { get; set; }
        public DbSet<TypeOutputMatTarget> TypeOutputMatTargets { get; set; }
        public DbSet<TypeParameterList> TypeParameterLists { get; set; }
        public DbSet<TypeProcess> TypeProcesss { get; set; }
        public DbSet<TypeProcessInstructions> TypeProcessInstructionss { get; set; }
        public DbSet<TypeTimeStamp> TypeTimeStamps { get; set; }

        //Machine
        public DbSet<Defination> Definations { get; set; }
        public DbSet<InputCoil> InputCoils { get; set; }
        public DbSet<InputCoilApplyingUnit> InputCoilApplyingUnits { get; set; }
        public DbSet<InputCoilAttachment> InputCoilAttachments { get; set; }
        public DbSet<InputCoilBasicData> InputCoilBasicDatas { get; set; }
        public DbSet<InputCoilDefect> InputCoilDefects { get; set; }
        public DbSet<InputCoilMachine> InputCoilMachines { get; set; }
        public DbSet<InputCoilRemark> InputCoilRemarks { get; set; }
        public DbSet<InputCoilRewinder> InputCoilRewinders { get; set; }
        public DbSet<InputCoilRewinderOnePressure> InputCoilRewinderOnePressures { get; set; }
        public DbSet<InputCoilRewinderOneTension> InputCoilRewinderOneTensions { get; set; }
        public DbSet<InputCoilRewinderTwoPressure> InputCoilRewinderTwoPressures { get; set; }
        public DbSet<InputCoilRewinderTwoTension> InputCoilRewinderTwoTensions { get; set; }
        public DbSet<InputCoilSlitPattern> InputCoilSlitPatterns { get; set; }
        public DbSet<InputCoilSlitPatternDetail> InputCoilSlitPatternDetails { get; set; }
        public DbSet<InputCoilSpeedCharacteristic> InputCoilSpeedCharacteristics { get; set; }
        public DbSet<InputCoilSuction> InputCoilSuctions { get; set; }
        public DbSet<OutputCoil> OutputCoils { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterApplyingUnit> ParameterApplyingUnits { get; set; }
        public DbSet<ParameterBasicData> ParameterBasicDatas { get; set; }
        public DbSet<ParameterContactRoll> ParameterContactRolls { get; set; }
        public DbSet<ParameterDensity> ParameterDensitys { get; set; }
        public DbSet<ParameterHeadTailScrap> ParameterHeadTailScraps { get; set; }
        public DbSet<ParameterLubracationRoll> ParameterLubracationRolls { get; set; }
        public DbSet<ParameterMachine> ParameterMachines { get; set; }
        public DbSet<ParameterRewinder> ParameterRewinders { get; set; }
        public DbSet<ParameterRewinderOnePressure> ParameterRewinderOnePressures { get; set; }
        public DbSet<ParameterRewinderOneTension> ParameterRewinderOneTensions { get; set; }
        public DbSet<ParameterRewinderTwoPressure> ParameterRewinderTwoPressures { get; set; }
        public DbSet<ParameterRewinderTwoTension> ParameterRewinderTwoTensions { get; set; }
    }
}
