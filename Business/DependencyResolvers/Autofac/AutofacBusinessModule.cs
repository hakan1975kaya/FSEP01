using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Concrete.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using PLC.Abstract;
using PLC.Concrete;
using PLC.Helper;
using System.Diagnostics;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

            builder.RegisterType<PlcHelper>().As<IPlcHelper>();
            builder.RegisterType<PlcDal>().As<IPlcDal>();
            builder.RegisterType<PlcManager>().As<IPlcService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
