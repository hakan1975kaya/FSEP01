using Core.Entities.Concrete;
using Core.Utilities.Service;
using Entities.Concrete.Entities.WEB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demand = Core.Entities.Concrete.Demand;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class FSEP01LOGContext : DbContext
    {
        private IConfiguration _configuration;
        public FSEP01LOGContext()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FSEP01LOG"));
        }
        public DbSet<ApiLog> ApiLogs { get; set; }
        public DbSet<WebLog> WebLogs { get; set; }

    }
}
