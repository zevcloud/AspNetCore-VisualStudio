using System;
namespace AspNetCore.Mvc.Entities
{
    [SqlSugar.SugarTable("GVcms_SystemManagerRoleValue")]
    /// <summary>
    /// 系统角色资料详情表
    /// </summary>
    public class SystemManagerRoleValueModel
    {
        /// <summary>
        /// 系统角色资料详情表Id
        /// </summary>
        public int SystemManagerRoleValueId { get; set; }

        /// <summary>
        /// 系统角色表Id
        /// </summary>
        public int SystemManagerRoleId { get; set; }

        /// <summary>
        /// 当前角色所拥有的权限之一(程序中会把当前实体组装成List)
        /// </summary>
        public int SystemManagerRoleValueAction { get; set; }

        /// <summary>
        /// 当前角色详情添加的时间=> 其实没什么用,资料一旦修改,当前资料就会重新添加
        /// </summary>
        public DateTime SystemManagerRoleValueTime { get; set; }

        /// <summary>
        /// 因项目使用导航权限,此处使用导航ID
        /// </summary>
        public int SystemManagerRoleNavId { get; set; }
    }
}
