using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context.Config;
using SqlSugar;
using AspNetCore.Mvc.Entities;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Utils.Enum;
using static AspNetCore.Mvc.Utils.Enum.EnumManager.Manager;
using AspNetCore.Mvc.Entities.Forms;

namespace AspNetCore.Mvc.Context
{

    /// <summary>
    /// 角色表底层
    /// zev
    /// 2018.5.28
    /// </summary>
    public class SystemManagerRoleDb : SqlSugarBaseRepository<SystemManagerRoleModel>, ISystemManagerRoleDb
    {
        #region 新增角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleModel">角色实体</param>
        /// <param name="valueList">角色值</param>
        /// <returns></returns>
        public DbResult<bool> SystemRoleValueAdd(SystemManagerRoleModel roleModel, List<Entities.Forms.RoleCommit> valueList)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var result = conn.Ado.UseTran(() =>
                {
                    var begin = conn.Insertable<SystemManagerRoleModel>(roleModel).ExecuteReturnIdentity();
                    //判断添加的角色权限
                    if (roleModel.SystemManagerRoleLevel == (int)OrdinaryManager)
                    {
                        if (valueList.Count > 0)
                        {
                            var list = new List<SystemManagerRoleValueModel>();
                            foreach (var item in valueList)
                            {
                                var model = new SystemManagerRoleValueModel()
                                {
                                    SystemManagerRoleId = begin,
                                    SystemManagerRoleNavId = item.QueryNavId,
                                    SystemManagerRoleValueAction = item.QueryActionId,
                                    SystemManagerRoleValueId = 0,
                                    SystemManagerRoleValueTime = DateTime.Now
                                };
                                list.Add(model);
                            }
                            conn.Insertable<SystemManagerRoleValueModel>(list.ToArray()).ExecuteCommand();
                        }
                    }

                });
                return result;
            }
        }
        #endregion

        #region  修改角色信息

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleModel">角色实体</param>
        /// <param name="valueList">角色值</param>
        /// <returns></returns>
        public DbResult<bool> SystemRoleValueUpdate(SystemManagerRoleModel roleModel, List<RoleCommit> valueList)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var result = conn.Ado.UseTran(() =>
                {
                    var begin = conn.Updateable<SystemManagerRoleModel>(roleModel).ExecuteCommand();
                    //判断添加的角色权限
                    if (roleModel.SystemManagerRoleLevel == (int)OrdinaryManager)
                    {
                        //先删除该用户之前的权限
                        conn.Deleteable<SystemManagerRoleValueModel>().Where(t => t.SystemManagerRoleId == roleModel.SystemManagerRoleId).ExecuteCommand();
                        if (valueList.Count > 0)
                        {
                            var list = new List<SystemManagerRoleValueModel>();
                            foreach (var item in valueList)
                            {
                                var model = new SystemManagerRoleValueModel()
                                {
                                    SystemManagerRoleId = roleModel.SystemManagerRoleId,
                                    SystemManagerRoleNavId = item.QueryNavId,
                                    SystemManagerRoleValueAction = item.QueryActionId,
                                    SystemManagerRoleValueId = 0,
                                    SystemManagerRoleValueTime = DateTime.Now
                                };
                                list.Add(model);
                            }
                            conn.Insertable<SystemManagerRoleValueModel>(list.ToArray()).ExecuteCommand();
                        }
                    }
                });
                return result;
            }
        }
        #endregion

        #region  获取角色信息，且获取详情信息
        /// <summary>
        /// 获取角色信息，且获取详情信息
        /// </summary>
        /// <param name="responeRoleId"></param>
        /// <returns></returns>
        public SystemManagerRoleModel GetRoleModel(int responeRoleId)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<SystemManagerRoleModel>().Where(t => t.SystemManagerRoleId == responeRoleId).First();
                if (query != null)
                {
                    if (query.SystemManagerRoleLevel == (int)OrdinaryManager)
                    {
                        var list = conn.Queryable<SystemManagerRoleValueModel>().Where(t => t.SystemManagerRoleId == responeRoleId).ToList();
                        query.GetSystemManagerRoleValueList = list;
                    }
                }
                return query;
            }
        }
        #endregion

        #region 获取实例信息列表，不获取子表详情
        /// <summary>
        /// 搜索日志
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">返回总数</param>
        /// <param name="keyword">搜索关键词</param>
        /// <returns></returns>
        public List<SystemManagerRoleModel> GetRoleList(int pageIndex, int pageSize, out int totalCount, string keyword)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var refCount = 0;
                var query = conn.Queryable<SystemManagerRoleModel>().WhereIF(!string.IsNullOrEmpty(keyword), t => t.SystemManagerRoleName.Contains(keyword)).OrderBy(t => t.SystemManagerRoleCreateTime, OrderByType.Desc).ToPageList(pageIndex, pageSize, ref refCount);
                totalCount = refCount;
                return query;
            }
        }
        #endregion

        #region  管理员详情页可以用的获取权限实例列表
        /// <summary>
        /// 管理员详情页可以用的获取权限实例列表=>获取状态为启用的
        /// </summary>
        /// <returns></returns>
        public List<SystemManagerRoleModel> GetRoleList()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<SystemManagerRoleModel>().Where(t => t.SystemManagerRoleStatus == (int)EnumStatus.Status.Enable).OrderBy(t => t.SystemManagerRoleCreateTime, OrderByType.Desc).ToList();
                return query;
            }
        }
        #endregion

        #region  获取角色正常的角色
        /// <summary>
        /// 获取角色正常的角色
        /// </summary>
        /// <returns></returns>
        public int GetEableRoleCount()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<SystemManagerRoleModel>().Where(t => t.SystemManagerRoleStatus == (int)EnumStatus.Status.Enable).Count();
                return query;
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
                var rows = conn.Deleteable<SystemManagerRoleModel>().In(deleteManagerList).ExecuteCommand();
                return rows;
            }
        }
        #endregion

        #region 获取角色信息,然后获取详情
        /// <summary>
        /// 获取角色信息,然后获取详情
        /// </summary>
        /// <returns></returns>
        public List<SystemManagerRoleModel> GetRoleDetailList()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var list = conn.Queryable<SystemManagerRoleModel>().OrderBy(t => t.SystemManagerRoleCreateTime, OrderByType.Desc).ToList();
                foreach (var item in list)
                {
                    if (item.SystemManagerRoleLevel == (int)OrdinaryManager)
                    {
                        item.GetSystemManagerRoleValueList = conn.Queryable<SystemManagerRoleValueModel>().Where(t => t.SystemManagerRoleId == item.SystemManagerRoleId).ToList();
                    }
                    else
                    {
                        continue;
                    }
                }
                return list;
            }
        }
        #endregion

        #region 获取全部角色信息
        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns></returns>
        public List<SystemManagerRoleModel> GetSystemRoleAllList()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<SystemManagerRoleModel>().ToList();
                return query;
            }
        }
        #endregion
    }
}
