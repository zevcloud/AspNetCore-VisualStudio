using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Utils.Enum;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Mvc.Web.Methods;
using AspNetCore.Mvc.Entities.Respone;
using AspNetCore.Mvc.Utils.Json;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Mvc.Web.Controllers
{
    /// <summary>
    /// AspNetCore 2.1
    /// 日志列表页
    /// zev
    /// </summary>
    public class LogController : Controller
    {
        public ISystemLogDb _db;

        public LogController(ISystemLogDb db)
        {
            _db = db;
        }

        /// <summary>
        /// 日志列表页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(string keyword, int pageIndex = 1, int operId = -1)
        {
            var pageSize = 10;
            var pageKeyword = keyword;
            var totalCount = 0;
            var pageList = _db.GetSystemLogDbList(pageIndex, pageSize, out totalCount, pageKeyword, operId);
            string url = "/log/index?keyword=" + pageKeyword + "&openId=" + operId + "&pageIndex={__id__}";
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["totalCount"] = totalCount;
            ViewData["pageUrl"] = url;
            ViewData["centSize"] = 5;
            List<dynamic> dyList = new List<dynamic>();
            foreach (var item in pageList)
            {
                var id = item.LogId;
                var oper = ((EnumLog.Log)Enum.Parse(typeof(EnumLog.Log), item.LogOperId.ToString())).GetDisplayName();
                var actionName = item.LogActionName;
                var respone = ((EnumLog.Respone)Enum.Parse(typeof(EnumLog.Respone), item.LogResponeType.ToString())).GetDisplayName();
                var time = item.LogDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                dyList.Add(new { id, oper, actionName, respone, time });
            }
            var pageJson = Utils.Json.JsonUnits.ConvertJsonString(Utils.Json.JsonUnits.ToJSON(dyList));
            ViewData["ContextPageList"] = pageJson;
            return View();
        }

        /// <summary>
        /// 获取日志详情
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public IActionResult Detail(int id = 0)
        {
            if (id == 0)
            {
                HttpContext.Session.SetObjectAsJson("error_log", "msg:" + DateTime.Now.ToString("yyyyMMddHH"));
                throw new Exception("未找到匹配的日志信息");
            }
            var editModel = _db.GetSystemLogModel(id);
            ViewData["editModel"] = editModel ?? throw new Exception("未找到匹配的日志信息");
            return View();
        }

        #region 不使用
        [Route("api/query/log")]
        public JsonResult GetLogAsyncList(string keyword, int pageIndex = 1, int operId = -1)
        {
            var model = GetResultModel(keyword, pageIndex, operId);
            return Json(model);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        public HttpInvokeResultModel GetResultModel(string keyword, int pageIndex = 1, int operId = -1)
        {
            var pageSize = 50;
            var totalCount = 0;
            var jsonList = _db.GetSystemLogDbList(pageIndex, pageSize, out totalCount, keyword, operId);
            if (jsonList.Count == 0)
            {
                var errorModel = JsonResultHandle.Error("对不起,没有更多数据啦");
                return errorModel;
            }
            //获取总页数
            int total_page = totalCount % (pageSize - 0) == 0 ? totalCount / (pageSize - 0) : totalCount / (pageSize - 0) + 1;
            List<dynamic> dyList = new List<dynamic>();
            dynamic dynamicModel;
            foreach (var item in jsonList)
            {
                var id = item.LogId;
                var oper = ((EnumLog.Log)Enum.Parse(typeof(EnumLog.Log), item.LogOperId.ToString())).GetDisplayName();
                var actionName = item.LogActionName;
                var respone = ((EnumLog.Respone)Enum.Parse(typeof(EnumLog.Respone), item.LogResponeType.ToString())).GetDisplayName();
                var time = item.LogDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                dyList.Add(new { id, oper, actionName, respone, time });
            }
            dynamicModel = new { total_page, dyList };
            var returnModle = JsonResultHandle.Success("返回成功", dynamicModel);
            return returnModle;
        }
        #endregion


    }
}
