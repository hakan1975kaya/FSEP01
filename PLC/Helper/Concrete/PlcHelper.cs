using Core.Utilities.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PLC.Dtos;
using PLC.Helper.Abstract;
using S7.Net;
using S7.Net.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLC.Helper.Concrete
{
    public class PlcHelper : IPlcHelper
    {
        private IConfiguration _configuration;
        private PlcOptions _plcOptions;
        private Plc _plc;
        public PlcHelper()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            _plcOptions = _configuration.GetSection("PlcOptions").Get<PlcOptions>();
            _plc = new Plc(_plcOptions.IP, TsapPair.GetDefaultTsapPair(_plcOptions.CpuType, _plcOptions.Rack, _plcOptions.Slot));
            if (!_plc.IsConnected)
            {
                _plc.ReadTimeout = _plcOptions.ReadTimeout;
                _plc.WriteTimeout = _plcOptions.WriteTimeout;
                _plc.Open();
            }
        }
        public Plc Plc()
        {
            return _plc;
        }
    }
}
