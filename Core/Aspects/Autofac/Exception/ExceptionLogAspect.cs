using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Castle.DynamicProxy;
using Core.Constants.Messages;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Service;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using Core.Helpers;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;
        private RegistrationNumberHelper _registrationNumberHelper;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            Priority = 0;
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _registrationNumberHelper = Activator.CreateInstance<RegistrationNumberHelper>();
        }
        protected override void OnException(IInvocation invocation, System.Exception exception)
        {
            _loggerServiceBase.Error(GetLogDetailWithException(invocation, exception));
        }
        private LogDetailWithException GetLogDetailWithException(IInvocation invocation, System.Exception exception)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name,
                });
            }

            var registrationNumber = _registrationNumberHelper.GetRegistrationNumber();
            var remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = $"{invocation.Method.DeclaringType.Name}.{invocation.Method.Name}",
                LogParameters = logParameters,
                Date = DateTime.UtcNow,
                RemoteIpAddress = remoteIpAddress,
                RegistrationNumber = registrationNumber,
                Response = JsonConvert.SerializeObject(invocation.ReturnValue, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }),
                ExceptionMessage = exception.ToString()
            };

            return logDetailWithException;
        }










    }
}
