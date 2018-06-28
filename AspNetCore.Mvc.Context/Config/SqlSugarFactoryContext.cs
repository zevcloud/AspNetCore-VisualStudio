using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Mvc.Entities;
using SqlSugar;
namespace AspNetCore.Mvc.Context.Config
{

    /// <summary>
    /// 创建底层公用方法上下文
    /// </summary>
    public class SqlSugarFactoryContext
    {
        public SqlSugarClient Db;

        public SqlSugarFactoryContext()
        {
            Db = SqlSugarConnection.GetSqlSugarClient();
        }

        /// <summary>
        /// 管理员信息表
        /// </summary>
        public SqlSugarFactory<ManagerModel> ManagerDll { get { return new SqlSugarFactory<ManagerModel>(Db); } }

        /// <summary>
        /// 导航信息表
        /// </summary>
        public SqlSugarFactory<NavigationDb> NavDll { get { return new SqlSugarFactory<NavigationDb>(Db); } }
    }
}
