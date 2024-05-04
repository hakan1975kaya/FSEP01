using Core.Entities.Concrete;
using Core.Utilities.Service;
using Entities.Concrete.Entities.General.General;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;
using Entities.Concrete.Entities.PLC.General;
using Entities.Concrete.Entities.PLC.Machine;
using Entities.Concrete.Entities.PLC.Recipe;
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

        public DbSet<SlitPattern> SlitPatterns { get; set; }
        public DbSet<SlitPatternDetail> SlitPatternDetails { get; set; }

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
        //ProcessCoils
        public DbSet<ProcessCoil> ProcessCoils { get; set; }


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

        //PLC
        //Recipe
        public DbSet<PLCRecipe> PLCRecipes { get; set; }

        //PLC
        //Machine
        public DbSet<PLCBasicData> PLCBasicDatas { get; set; }
        public DbSet<PLCDensity> PLCDensitys { get; set; }
        public DbSet<PLCHandling> PLCHandlings { get; set; }
        public DbSet<PLCMachine> PLCMachines { get; set; }
        public DbSet<PLCMachineOverview> PLCMachineOverviews { get; set; }
        public DbSet<PLCRewinderPressure> PLCRewinderPressures { get; set; }
        public DbSet<PLCRewinderTension> PLCRewinderTensions { get; set; }
        public DbSet<PLCSuctionHydraulic> PLCSuctionHydraulics { get; set; }

        //PLC
        //General
        public DbSet<PLCGeneral> PLCGenerals { get; set; }
    }
}
