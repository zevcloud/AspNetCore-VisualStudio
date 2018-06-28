using AspNetCore.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Context.IDb
{
    /// <summary>
    /// 管理员底层接口层
    /// </summary>
    public interface IManagerDb
    {
        #region  实现管理员登录
        /// <summary>
        /// 实现管理员登录
        /// </summary>
        /// <param name="loginName">登录用户名</param>
        /// <param name="loginPass">登录用户密码(从前台传过来已被加密状态)</param>
        /// <returns></returns>
        ManagerModel GetManagerLogin(string loginName, string loginPass);
        #endregion

        #region  根据用户名查询SALT
        /// <summary>
        /// 根据用户名查询SALT
        /// </summary>
        /// <param name="managerName">登录名称</param>
        /// <returns></returns>
        string GetSaltForManagerName(string managerName);
        #endregion

        #region 添加状态下查询用户是否存在
        /// <summary>
        /// 添加状态下查询用户是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool GetManagerLoginNameIsAny(string loginName, int id);
        #endregion

        #region  获取管理员列表,不分页
        /// <summary>
        /// 获取管理员列表,不分页
        /// </summary>
        /// <returns></returns>
        List<ManagerModel> GetManagerList();
        #endregion

        #region  获取正常管理员的经营数量
        /// <summary>
        /// 获取正常管理员的经营数量
        /// </summary>
        /// <returns></returns>
        int GetManagerEableCount();
        #endregion

        #region  删除管理员信息,利用List<int>
        /// <summary>
        /// 删除管理员信息,利用List<int>
        /// </summary>
        /// <param name="deleteManagerList"></param>
        /// <returns></returns>
        int DeleteManagerInfo(List<int> deleteManagerList);
        #endregion

        #region  根据传过来的角色ID，判断是否有管理员使用该角色
        /// <summary>
        /// 根据传过来的角色ID，判断是否有管理员使用该角色
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        bool GetManagerUsingRole(int roleId);
        #endregion

    }
}
