﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract.General.General;
using Business.Abstract.PLC;
using Business.Abstract.PSI.Telegrams;
using Business.Concrete.General.General;
using Business.Concrete.PLC;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Concrete.Jwt;
using DataAccess.Abstract.General.General;
using DataAccess.Abstract.PSI.Telegrams;
using DataAccess.Abstract.PSI.Types;
using DataAccess.Concrete.EntityFramework.General.General;
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
            builder.RegisterType<DemandManager>().As<IDemandService>();
            builder.RegisterType<EFDemandDal>().As<IDemandDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<EFMenuDal>().As<IMenuDal>();
            builder.RegisterType<MenuManager>().As<IMenuService>();

            builder.RegisterType<EFRoleDal>().As<IRoleDal>();
            builder.RegisterType<RoleManager>().As<IRoleService>();

            builder.RegisterType<EFRoleDemandDal>().As<IRoleDemandDal>();
            builder.RegisterType<RoleDemandManager>().As<IRoleDemandService>();

            builder.RegisterType<EFRoleMenuDal>().As<IRoleMenuDal>();
            builder.RegisterType<RoleMenuManager>().As<IRoleMenuService>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();

            builder.RegisterType<UserRoleManager>().As<IUserRoleService>();
            builder.RegisterType<EFUserRoleDal>().As<IUserRoleDal>();

            builder.RegisterType<ApiLogManager>().As<IApiLogService>();
            builder.RegisterType<EFApiLogDal>().As<IApiLogDal>();

            builder.RegisterType<WebLogManager>().As<IWebLogService>();
            builder.RegisterType<EFWebLogDal>().As<IWebLogDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<Stopwatch>();

            //PLC
            builder.RegisterType<PLCHelper>().As<IPLCHelper>();
            builder.RegisterType<PLCDal>().As<IPLCDal>();
            builder.RegisterType<PLCManager>().As<IPLCService>();

            //PSI

            //Telegrams
            builder.RegisterType<EFPSIGeneralAckPES2L2Dal>().As<IPSIGeneralAckPES2L2Dal>();

            builder.RegisterType<EFPSIPingAckL22PESDal>().As<IPSIPingAckL22PESDal>();

            builder.RegisterType<EFPSIPingAckPES2L2Dal>().As<IPSIPingAckPES2L2Dal>();

            builder.RegisterType<EFPSIPingL22PESDal>().As<IPSIPingL22PESDal>();

            builder.RegisterType<EFPSIPingPES2L2Dal>().As<IPSIPingPES2L2Dal>();

            builder.RegisterType<EFPSIProcessDataPES2L2Dal>().As<IPSIProcessDataPES2L2Dal>();

            builder.RegisterType<EFPSIProcessStateL22PESDal>().As<IPSIProcessStateL22PESDal>();

            builder.RegisterType<EFPSIProdReportL22PESDal>().As<IPSIProdReportL22PESDal>();

            builder.RegisterType<EFPSIRequestProcessDataL22PESDal>().As<IPSIRequestProcessDataL22PESDal>();

            //Types
            builder.RegisterType<EFPSITypeDefectActionListDal>().As<IPSITypeDefectActionListDal>();

            builder.RegisterType<EFPSITypeDefectListDal>().As<IPSITypeDefectListDal>();

            builder.RegisterType<EFPSITypeHeaderDal>().As<IPSITypeHeaderDal>();

            builder.RegisterType<EFPSITypeInputMatCoordDal>().As<IPSITypeInputMatCoordDal>();

            builder.RegisterType<EFPSITypeInputMatDal>().As<IPSITypeInputMatDal>();

            builder.RegisterType<EFPSITypeMatIdDal>().As<IPSITypeMatIdDal>();

            builder.RegisterType<EFPSITypeOutputMatDal>().As<IPSITypeOutputMatDal>();

            builder.RegisterType<EFPSITypeOutputMatTargetDal>().As<IPSITypeOutputMatTargetDal>();

            builder.RegisterType<EFPSITypeParameterListDal>().As<IPSITypeParameterListDal>();

            builder.RegisterType<EFPSITypeProcessDal>().As<IPSITypeProcessDal>();

            builder.RegisterType<EFPSITypeProcessInstructionsDal>().As<IPSITypeProcessInstructionsDal>();

            builder.RegisterType<EFPSITypeTimeStampDal>().As<IPSITypeTimeStampDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
