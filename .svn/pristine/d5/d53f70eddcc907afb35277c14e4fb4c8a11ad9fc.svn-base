using System;
using System.Collections.Generic;
using static AspNetCore.Mvc.Utils.Enum.EnumYesNo;

namespace AspNetCore.Mvc.Entities
{
    [SqlSugar.SugarTable("GVcms_Navigation")]
    /// <summary>
    /// 后台管理导航表
    /// 2018.5.7
    /// zev
    /// </summary>
    public class NavigationModel
    {
        /// <summary>
        /// 导航ID
        /// </summary>
        public int NavId { get; set; }

        /// <summary>
        /// 导航唯一标识
        /// </summary>
        public string NavIdent { get; set; }

        /// <summary>
        /// 导航标题
        /// </summary>
        public string NavTitle { get; set; }

        /// <summary>
        /// 导航导向URL
        /// </summary>
        public string NavURL { get; set; } = "javascript:void(0)";

        /// <summary>
        /// 父级ID
        /// </summary>
        public int NavParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int NavSort { get; set; } = 99;

        /// <summary>
        /// 备注
        /// </summary>
        public string NavRemark { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用
        /// </summary>
        public int NavisLock { get; set; }

        /// <summary>
        /// 权限信息
        /// </summary>
        public string NavAction { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime NavInsertTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime NavModifyTime { get; set; }

        /// <summary>
        /// 是否是系统=> 是,不可删除 2018.6.13加入
        /// </summary>
        public int NavIsSys { get; set; } = (int)YesNo.NO;


        [SqlSugar.SugarColumn(IsIgnore =true)]
        /// <summary>
        /// 不参与CRUD,获取导航层级数据
        /// </summary>
        public List<NavigationModel> ActionList { get; set; }
    }
}
