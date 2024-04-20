using Core.Entities.Concrete;
using Core.Utilities.Service;
using Entities.Concrete.Entities.General.General;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
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
        public DbSet<PSIGeneralAckPES2L2> GeneralAckPES2L2s { get; set; }
        public DbSet<PSIPingAckL22PES> PingAckL22PESs { get; set; }
        public DbSet<PSIPingAckPES2L2> PingAckPES2L2s { get; set; }
        public DbSet<PSIPingL22PES> PingL22PESs { get; set; }
        public DbSet<PSIPingPES2L2> PingPES2L2s { get; set; }
        public DbSet<PSIProcessDataPES2L2> ProcessDataPES2L2s { get; set; }
        public DbSet<PSIProcessStateL22PES> ProcessStateL22PESs { get; set; }
        public DbSet<PSIProdReportL22PES> ProdReportL22PESs { get; set; }
        public DbSet<PSIRequestProcessDataL22PES> RequestProcessDataL22PESs { get; set; }

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

        //Machine
        public DbSet<Defination> Definations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<InputCoil> InputCoils { get; set; }
        public DbSet<InputCoilAttachment> InputCoilAttachments { get; set; }
        public DbSet<InputCoilDefect> InputCoilDefects { get; set; }
        public DbSet<InputCoilRemark> InputCoilRemarks { get; set; }

    }
}
