using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Mvc.Entities;
using AspNetCore.Mvc.Context.Config;
using SqlSugar;
using AspNetCore.Mvc.Context.IDb;

namespace AspNetCore.Mvc.Context
{

    /// <summary>
    /// 系统日志交互
    /// 2018.5.8
    /// zev
    /// </summary>
    public class SystemLogDb : SqlSugarBaseRepository<SystemOperLogModel>, ISystemLogDb
    {

        #region  日志搜索
        /// <summary>
        /// 搜索日志
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">返回总数</param>
        /// <param name="keyword">搜索关键词</param>
        /// <param name="operId">搜索的类型ID</param>
        /// <returns></returns>
        public List<SystemOperLogModel> GetSystemLogDbList(int pageIndex, int pageSize, out int totalCount, string keyword, int operId = -1)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var refCount = 0;
                var query = conn.Queryable<SystemOperLogModel>().WhereIF(!string.IsNullOrEmpty(keyword), t => t.LogNewAccess.Contains(keyword) || t.LogOldAccess.Contains(keyword) || t.LogUserId.ToString().Contains(keyword) || t.LogActionName.Contains(keyword) || t.LogObjectRemark.Contains(keyword) || t.LogPageUrl.Contains(keyword) || t.LogCurrentIP.Contains(keyword)).WhereIF(operId > -1, t => t.LogOperId == operId).OrderBy(t => t.LogDateTime, OrderByType.Desc).ToPageList(pageIndex, pageSize, ref refCount);
                totalCount = refCount;
                return query;
            }
        }
        #endregion

        #region 删除日志信息,利用List<int>
        /// <summary>
        /// 删除日志信息,利用List<int>
        /// </summary>
        /// <returns></returns>
        public int DeleteLogInfo(List<int> deleteLogList)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var rows = conn.Deleteable<SystemOperLogModel>().In(deleteLogList).ExecuteCommand();
                return rows;
            }
        }
        #endregion

        #region 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键参数ID</param>
        /// <returns></returns>
        public SystemOperLogModel GetSystemLogModel(int id)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<SystemOperLogModel>().Where(t => t.LogId == id).First();
                return query;
            }
        }
        #endregion
    }
}
