using AspNetCore.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Context.IDb
{

    /// <summary>
    /// AspNetCore 2.1
    /// 系统日志接口类
    /// </summary>
    public interface ISystemLogDb
    {
        /// <summary>
        /// 搜索日志
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">返回总数</param>
        /// <param name="keyword">搜索关键词</param>
        /// <param name="operId">搜索的类型ID</param>
        /// <returns></returns>
        List<SystemOperLogModel> GetSystemLogDbList(int pageIndex, int pageSize, out int totalCount, string keyword, int operId = -1);

        /// <summary>
        /// 删除日志信息,利用List<int>
        /// </summary>
        /// <returns></returns>
        int DeleteLogInfo(List<int> deleteLogList);
    }
}
