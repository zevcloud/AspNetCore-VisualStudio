using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Mvc.Context.IDb;
using SqlSugar;

namespace AspNetCore.Mvc.Context.Config
{
    public class SqlSugarBaseRepository<T>:ISqlSugarBaseRepository<T> where T:class
    {
        public SqlSugarClient Db;
        public SqlSugarBaseRepository()
        {
            Db = SqlSugarConnection.GetSqlSugarClient();
        }
    
    }
}
