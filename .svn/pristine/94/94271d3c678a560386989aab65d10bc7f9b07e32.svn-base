using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Mvc.Entities.Respone;
namespace AspNetCore.Mvc.Web.Methods
{
    /// <summary>
    /// 返回JSON=>实体
    /// </summary>
    public class JsonResultHandle
    {
        public static HttpInvokeResultModel Error(string message, dynamic dyObject = null)
        {
            var errorModel = new HttpInvokeResultModel()
            {
                CustomObject = dyObject,
                IsSuccess = false,
                Message = message,
                ReturnCode = 0
            };
            return errorModel;
        }

        public static HttpInvokeResultModel Success(string message, dynamic dyObject = null)
        {
            var errorModel = new HttpInvokeResultModel()
            {
                CustomObject = dyObject,
                IsSuccess = true,
                Message = message,
                ReturnCode = 1
            };
            return errorModel;
        }
    }
}
