using System;
using System.Collections.Generic;
using AspNetCore.Mvc.Utils.Enum;
using static AspNetCore.Mvc.Utils.Enum.EnumYesNo;

namespace AspNetCore.Mvc.Entities
{
    [SqlSugar.SugarTable("GVcms_SystemManagerRole")]
    /// <summary>
    /// 管理员角色表
    /// 2018.5.7
    /// zev
    /// </summary>
    public class SystemManagerRoleModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int SystemManagerRoleId { get; set; } = 0;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string SystemManagerRoleName { get; set; }

        /// <summary>
        /// 是否是系统内置
        /// </summary>
        public int SystemManagerRoleIsSys { get; set; } = 0;

        /// <summary>
        /// 角色排序
        /// </summary>
        public int SystemManagerRoleSort { get; set; } = 99;

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int SystemManagerRoleCreateUserId { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime SystemManagerRoleCreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 角色状态
        /// </summary>
        public int SystemManagerRoleStatus { get; set; } = (int)EnumStatus.Status.Enable;

        /// <summary>
        /// 角色等级
        /// 枚举类型：是否超级管理员 是否普通管理员
        /// </summary>
        public int SystemManagerRoleLevel { get; set; } = -1;

        /// <summary>
        /// 是否放进回收站  预留
        /// </summary>
        public int SystemRecycleBin { get; set; } = (int)YesNo.NO;

        /// <summary>
        /// 添加 IsIgnore = true 保证 此处不参加ORM的CRUD
        /// </summary>
        [SqlSugar.SugarColumn(IsIgnore = true)]
        /// <summary>
        /// 当前角色所拥有的权限组
        /// </summary>
        public List<SystemManagerRoleValueModel> GetSystemManagerRoleValueList { get; set; }
    }
}
