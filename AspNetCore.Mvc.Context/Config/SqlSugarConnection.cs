
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;


namespace AspNetCore.Mvc.Context.Config
{

    /// <summary>
    /// 连接数据库配置
    /// </summary>
    public class SqlSugarConnection
    {

        public static SqlSugarClient GetSqlSugarClient()
        {
            string connection= SqlSugarConnectionSettings.Configuration["ConnectionString:Default"];
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = connection,
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.SystemTable,
                IsAutoCloseConnection = true
            });
            return db;
        }

    }
}
