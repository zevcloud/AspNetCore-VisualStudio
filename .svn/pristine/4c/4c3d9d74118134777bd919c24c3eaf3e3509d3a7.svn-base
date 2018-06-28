using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context.IDb;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Mvc.Utils.Enum;
using AspNetCore.Mvc.Utils.Json;

namespace AspNetCore.Mvc.Web.Controllers
{
    public class RoleController : Controller
    {
        public ISystemManagerRoleDb _db;

        public RoleController(ISystemManagerRoleDb db)
        {
            _db = db;
        }

        /// <summary>
        /// 角色列表页
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var pageList = _db.GetSystemRoleAllList();
            List<dynamic> dynamicsList = new List<dynamic>();
            foreach (var item in pageList)
            {
                var id = item.SystemManagerRoleId;
                var name = item.SystemManagerRoleName;
                var createTime = item.SystemManagerRoleCreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                var level = ((EnumManager.Manager)Enum.Parse(typeof(EnumManager.Manager), item.SystemManagerRoleLevel.ToString())).GetDisplayName();
                var status = ((EnumStatus.Status)Enum.Parse(typeof(EnumStatus.Status), item.SystemManagerRoleStatus.ToString())).GetDisplayName();
                dynamicsList.Add(new { id, name, createTime, level, status });
            }
            var jsonText = JsonUnits.ConvertJsonString(JsonUnits.ToJSON(dynamicsList));
            ViewData["jsonData"] = jsonText;
            return View();
        }

        #region  修改角色名称
        [Route("api/update/rolename")]
        public JsonResult GetUpdateRoleName(string name, int id)
        {
            return Json(new { error = 1, msg = "再见" });
        }
        #endregion


    }
}