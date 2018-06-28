using AspNetCore.Mvc.Entities;
using AspNetCore.Mvc.Entities.Forms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Context.IDb
{
    /// <summary>
    /// 角色权限接口层
    /// </summary>
    public interface ISystemManagerRoleDb
    {
        #region 新增角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roleModel">角色实体</param>
        /// <param name="valueList">角色值</param>
        /// <returns></returns>
        DbResult<bool> SystemRoleValueAdd(SystemManagerRoleModel roleModel, List<Entities.Forms.RoleCommit> valueList);
        #endregion

        #region  修改角色
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roleModel">角色实体</param>
        /// <param name="valueList">角色值</param>
        /// <returns></returns>
        DbResult<bool> SystemRoleValueUpdate(SystemManagerRoleModel roleModel, List<RoleCommit> valueList);
        #endregion

        #region  获取角色信息，且获取详情信息
        /// <summary>
        /// 获取角色信息，且获取详情信息
        /// </summary>
        /// <param name="responeRoleId"></param>
        /// <returns></returns>
        SystemManagerRoleModel GetRoleModel(int responeRoleId);
        #endregion

        #region 获取实例信息列表，不获取子表详情
        /// <summary>
        /// 获取实例信息列表，不获取子表详情
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页数</param>
        /// <param name="totalCount">返回总数</param>
        /// <param name="keyword">搜索关键词</param>
        /// <returns></returns>
        List<SystemManagerRoleModel> GetRoleList(int pageIndex, int pageSize, out int totalCount, string keyword);
        #endregion

        #region  管理员详情页可以用的获取权限实例列表
        /// <summary>
        /// 管理员详情页可以用的获取权限实例列表=>获取状态为启用的
        /// </summary>
        /// <returns></returns>
        List<SystemManagerRoleModel> GetRoleList();
        #endregion

        #region  获取角色正常的角色
        /// <summary>
        /// 获取角色正常的角色
        /// </summary>
        /// <returns></returns>
        int GetEableRoleCount();
        #endregion;

        #region 删除管理员信息,利用List<int>
        /// <summary>
        /// 删除管理员信息,利用List<int>
        /// </summary>
        /// <param name="deleteManagerList"></param>
        /// <returns></returns>
        int DeleteManagerInfo(List<int> deleteManagerList);
        #endregion

        #region 获取角色信息,然后获取详情
        /// <summary>
        /// 获取角色信息,然后获取详情
        /// </summary>
        /// <returns></returns>
        List<SystemManagerRoleModel> GetRoleDetailList();
        #endregion

        #region  获取全部角色信息
        /// <summary>
        /// 获取全部角色信息
        /// </summary>
        /// <returns></returns>
        List<SystemManagerRoleModel> GetSystemRoleAllList();
        #endregion
    }
}
