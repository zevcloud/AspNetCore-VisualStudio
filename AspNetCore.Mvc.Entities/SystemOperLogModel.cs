using System;
namespace AspNetCore.Mvc.Entities
{
    [SqlSugar.SugarTable("GVcms_SystemLog")]
    /// <summary>
    /// 系统后台管理操作日志
    /// 2018.5.7
    /// zev
    /// </summary>
    public class SystemOperLogModel
    {
        /// <summary>
        /// 自增长ID，日志ID 
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// 日志操作的类型ID
        /// </summary>
        public int LogOperId { get; set; }

        /// <summary>
        /// 日志的新数据
        /// </summary>
        public string LogNewAccess { get; set; }

        /// <summary>
        /// 日志的原来数据
        /// </summary>
        public string LogOldAccess { get; set; }

        /// <summary>
        /// 操作者ID
        /// </summary>
        public int LogUserId { get; set; }

        /// <summary>
        /// 日志操作时间
        /// </summary>
        public DateTime LogDateTime { get; set; }

        /// <summary>
        /// 日志操作备注
        /// </summary>
        public string LogObjectRemark { get; set; }

        /// <summary>
        /// 日志的访问控制器中的Action名称
        /// </summary>
        public string LogActionName { get; set; }

        /// <summary>
        /// 日志访问当前的链接
        /// </summary>
        public string LogPageUrl { get; set; }

        /// <summary>
        /// 日志访问上一次链接
        /// </summary>
        public string LogLastPageUrl { get; set; }

        /// <summary>
        /// 当前访问者的IP地址
        /// </summary>
        public string LogCurrentIP { get; set; }

        /// <summary>
        /// 枚举方式,例如:0 action,1 api
        /// </summary>
        public int LogResponeType { get; set; }
    }
}
