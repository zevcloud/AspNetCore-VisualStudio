using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCore.Mvc.Utils.Enum
{

    /// <summary>
    /// 创建是或否的枚举
    /// </summary>
    public class EnumYesNo
    {
        public enum YesNo
        {
            [EnumAttributeDesc("是")]
            [Display(Name = "是")]
            YES = 1,
            [EnumAttributeDesc("否")]
            [Display(Name = "否")]
            NO = 0
        }
    }
}
