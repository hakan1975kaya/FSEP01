using Core.Utilities.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class RegistrationNumberHelper
    {
        private IHttpContextAccessor _httpContextAccessor;
        public RegistrationNumberHelper()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public int GetRegistrationNumber()
        {
            var registrationNumber = 0;

            if (_httpContextAccessor != null)
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    if (_httpContextAccessor.HttpContext.User != null)
                    {
                        if (_httpContextAccessor.HttpContext.User.Claims != null)
                        {
                            if (_httpContextAccessor.HttpContext.User.Claims.Count() > 0)
                            {
                                var registrationNumberString = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber).Value;
                                if (!string.IsNullOrEmpty(registrationNumberString))
                                {
                                    registrationNumber = Convert.ToInt32(registrationNumberString);
                                }
                            }
                        }
                    }
                }
            }
            return registrationNumber;
        }






    }
}
