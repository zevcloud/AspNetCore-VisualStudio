using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Mvc.Utils;
using SqlSugar;
using System.Linq.Expressions;
using AspNetCore.Mvc.Context.Config;
using AspNetCore.Mvc.Entities;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Utils.Enum;
using static AspNetCore.Mvc.Utils.Enum.EnumStatus;

namespace AspNetCore.Mvc.Context
{

    /// <summary>
    /// 管理员表，底层实现
    /// </summary>
    public class ManagerDb : SqlSugarBaseRepository<ManagerModel>, IManagerDb
    {
        #region 实现管理员登录

        /// <summary>
        /// 实现管理员登录
        /// </summary>
        /// <param name="loginName">登录用户名</param>
        /// <param name="loginPass">登录用户密码(从前台传过来已被加密状态)</param>
        /// <returns></returns>
        public ManagerModel GetManagerLogin(string loginName, string loginPass)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var queryAble = conn.Queryable<ManagerModel>().Where(t => t.ManagerName == loginName && t.ManagerPass == loginPass).First();
                return queryAble;
            }
        }
        #endregion

        #region 根据用户名查询SALT
        /// <summary>
        /// 根据用户名查询SALT
        /// </summary>
        /// <param name="managerName">登录名称</param>
        /// <returns></returns>
        public string GetSaltForManagerName(string managerName)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<ManagerModel>().Where(t => t.ManagerName == managerName).Select(t => t.ManagerSalt).ToString();
                return query;
            }
        }
        #endregion

        #region 添加状态下查询用户是否存在
        public bool GetManagerLoginNameIsAny(string loginName, int id)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                // 添加状态：直接判断该用户名是否存在
                // 编辑状态：除此ID外是否存在该用户名
                bool query = false;
                if (id > 0)
                {
                    query = conn.Queryable<ManagerModel>().Where(t => t.ManagerId != id).Where(t => t.ManagerName == loginName).Any();
                }
                else
                {
                    query = conn.Queryable<ManagerModel>().Where(t => t.ManagerName == loginName).Any();
                }
                return query;
            }
        }
        #endregion

        #region 获取管理员列表
        /// <summary>
        /// 获取管理员列表,不分页
        /// </summary>
        /// <returns></returns>
        public List<ManagerModel> GetManagerList()
        {
            using (var db = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = db.Queryable<ManagerModel>().OrderBy(t => t.ManagerCount, OrderByType.Desc).OrderBy(t => t.ManagerInsertTime, OrderByType.Desc).ToList();
                return query;
            }
        }
        #endregion

        #region 获取正常管理员的经营数量
        /// <summary>
        /// 获取正常管理员的经营数量
        /// </summary>
        /// <returns></returns>
        public int GetManagerEableCount()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var count = conn.Queryable<ManagerModel>().Where(t => t.ManagerStatus == (int)Status.Enable).Count();
                return count;
            }
        }
        #endregion

        #region 删除管理员信息,利用List<int>
        /// <summary>
        /// 删除管理员信息,利用List<int>
        /// </summary>
        /// <param name="deleteManagerList"></param>
        /// <returns></returns>
        public int DeleteManagerInfo(List<int> deleteManagerList)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var rows = conn.Deleteable<ManagerModel>().In(deleteManagerList).ExecuteCommand();
                return rows;
            }
        }
        #endregion

        #region 根据传过来的角色ID，判断是否有管理员使用该角色
        /// <summary>
        /// 根据传过来的角色ID，判断是否有管理员使用该角色
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public bool GetManagerUsingRole(int roleId)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<ManagerModel>().Where(t => t.ManagerRoleId == roleId).Any();
                return query;
            }
        }
        #endregion
    }
}
