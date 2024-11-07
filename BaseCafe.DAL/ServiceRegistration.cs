using BaseCafe.DAL.Context;
using BaseCafe.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL
{
    public static class ServiceRegistration
    {
        public static void AddDalService(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
         
            
        }
    }
}
