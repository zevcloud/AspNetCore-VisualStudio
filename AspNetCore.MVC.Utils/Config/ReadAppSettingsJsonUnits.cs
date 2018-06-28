
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Utils.Config
{

    /// <summary>
    /// 读取AppSettingsJSON
    /// </summary>
    public class ReadAppSettingsJsonUnits
    {

        public static string _connectionString;

        public static IConfiguration Configuration { get; set; }

        static ReadAppSettingsJsonUnits()
        {
            Configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true }).Build();
        }      
    }
}
