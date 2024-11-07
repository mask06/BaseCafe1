using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCafe.DAL
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("conn");
            }
        }
    }
}
