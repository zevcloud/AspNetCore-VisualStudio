using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration.Json;

namespace AspNetCore.Mvc.Context.Config
{

    /// <summary>
    /// 读取连接字符串
    /// </summary>
    public class SqlSugarConnectionSettings
    {
        public static string _connectionString;

        public static IConfiguration Configuration { get; set; }

        static SqlSugarConnectionSettings()
        {
            Configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true }).Build();    
        }
    }
}
