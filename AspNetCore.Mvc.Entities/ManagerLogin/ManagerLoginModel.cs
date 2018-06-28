using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCore.Mvc.Entities.ManagerLogin
{
    /// <summary>
    /// 管理员登录实体
    /// </summary>
    public class ManagerLoginModel
    {
        /// <summary>
        /// 会员登录名称
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 会员登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 是否校验解锁
        /// </summary>
        public int LoginVail { get; set; } = 0;

        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 登录来源
        /// </summary>
        public string LoginRef { get; set; }
    }
}
