using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Mvc.Entities.Respone;
using AspNetCore.Mvc.Utils.Enum;
using AspNetCore.Mvc.Utils.Json;
namespace AspNetCore.Mvc.Web.Methods
{
    /// <summary>
    /// 返回JSON-Web封装
    /// </summary>
    public static class HttpResponseMessageJsonHandle
    {
        #region 返回Error错误
        /// <summary>
        ///  返回Error错误
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="data">返回数据,非必填</param>
        /// <returns></returns>
        public static HttpResponseMessage Error(string message, dynamic data = null)
        {
            var model = new HttpInvokeResultModel()
            {
                CustomObject = data,
                IsSuccess = false,
                Message = message,
                ReturnCode = 0
            };
            return JsonUnits.ResponeJSON(model);
        }
        #endregion

        #region 返回Success正确
        /// <summary>
        ///  返回Success正确
        /// </summary>
        /// <param name="message">正确信息</param>
        /// <param name="data">返回数据,非必填</param>
        public static HttpResponseMessage Success(string message, dynamic data = null)
        {
            var model = new HttpInvokeResultModel()
            {
                CustomObject = data,
                IsSuccess = true,
                Message = message,
                ReturnCode = 1
            };
            return JsonUnits.ResponeJSON(model);
        }
        #endregion

        #region 返回Base主
        /// <summary>
        ///  返回Base主
        /// </summary>
        /// <param name="message">返回信息</param>
        /// <param name="data">返回数据,非必填</param>
        public static HttpResponseMessage BaseHandle(int errorCode, string message, dynamic dynamic = null)
        {
            var model = new HttpInvokeResultModel()
            {
                CustomObject = dynamic,
                IsSuccess = errorCode == 1 ? true : false,
                Message = message,
                ReturnCode = errorCode
            };
            return JsonUnits.ResponeJSON(model);
        }
        #endregion

    }
}
