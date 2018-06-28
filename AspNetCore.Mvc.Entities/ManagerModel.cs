using AspNetCore.Mvc.Utils.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Mvc.Entities
{
    [SqlSugar.SugarTable("GVcms_Manager")]
    /// <summary>
    /// 管理员角色表
    /// 2018.5.5
    /// zev
    /// </summary>
    public class ManagerModel
    {
        /// <summary>
        /// 自增长管理员ID
        /// </summary>
        public int ManagerId { get; set; } = 0;

        /// <summary>
        /// 管理员用户名/登录名
        /// </summary>
        [DisplayName("管理员用户名")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "请输入用户名")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "用户名长度必须在{2}和{1}之间")]
        public string ManagerName { get; set; } = string.Empty;

        /// <summary>
        /// 管理员用户密码
        /// </summary>
        public string ManagerPass { get; set; } = string.Empty;

        [SqlSugar.SugarColumn(IsIgnore = true)]
        /// <summary>
        /// 管理员确认用户密码
        /// </summary>
        public string ManagerREPass { get; set; } = string.Empty;

        /// <summary>
        /// 管理员密码加密秘钥
        /// </summary>
        public string ManagerSalt { get; set; } = string.Empty;

        /// <summary>
        /// 选填项, 真实姓名
        /// </summary>
        public string ManagerTrueName { get; set; } = string.Empty;

        /// <summary>
        /// 选填项,邮箱
        /// </summary>
        public string ManagerEmail { get; set; } = string.Empty;

        /// <summary>
        /// 选填项，手机号码
        /// </summary>
        public string ManagerTel { get; set; } = string.Empty;

        /// <summary>
        /// 该用户的角色
        /// </summary>
        public int ManagerRoleId { get; set; } = 0;

        /// <summary>
        /// 该用户添加时间
        /// </summary>
        public DateTime ManagerInsertTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 管理员登录次数
        /// </summary>
        public int ManagerCount { get; set; } = 0;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ManagerModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 账号状态
        /// </summary>
        public int ManagerStatus { get; set; } = (int)EnumStatus.Status.Enable;
    }
}
