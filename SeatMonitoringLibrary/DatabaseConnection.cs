using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SeatMonitoringLibrary
{
    public static class DatabaseConnection
    {
    
      public  static string ConnString(string name)
        {

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
