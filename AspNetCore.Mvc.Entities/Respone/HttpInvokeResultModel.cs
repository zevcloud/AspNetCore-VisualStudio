using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace AspNetCore.Mvc.Entities.Respone
{
    public class HttpInvokeResultModel
    {
        /// <summary>
        /// 返回的消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        public int ReturnCode { get; set; }

        /// <summary>
        /// 返回的自定义数据
        /// </summary>
        public dynamic CustomObject { get; set; }
    }
}
