using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Utils.Json;
using AspNetCore.Mvc.Context.Config;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCore.Mvc.Web.Controllers
{
    public class ManagerController : Controller
    {
        public IManagerDb _managerdb;

        public SqlSugarFactoryContext _context;

        public ISystemManagerRoleDb _roledb;

        public ManagerController(IManagerDb managerDb, SqlSugarFactoryContext context, ISystemManagerRoleDb roledb)
        {
            _managerdb = managerDb;
            _context = context;
            _roledb = roledb;
        }

        #region   管理员首页/列表页
        public IActionResult Index()
        {
            var coverList = _managerdb.GetManagerList();
            List<dynamic> dynamicsList = new List<dynamic>();
            foreach (var item in coverList)
            {
                var id = item.ManagerId;
                var title = item.ManagerName;
                var addTime = item.ManagerInsertTime.ToString("yyyy-MM-dd HH:mm:ss");
                var updateTime = item.ManagerModifyTime.ToString("yyyy-MM-dd HH:mm:ss");
                var loginCount = item.ManagerCount;
                dynamicsList.Add(new { id, title, addTime, updateTime, loginCount });
            }
            var jsonText = JsonUnits.ConvertJsonString(JsonUnits.ToJSON(dynamicsList));
            ViewData["jsonData"] = jsonText;
            return View();
        }
        #endregion


        #region 管理员详情
        /// <summary>
        /// 新增/修改 管理员详情界面
        /// </summary>
        /// <param name="id">id 不稳定因素 >0 修改  ==0 增加</param>
        /// <returns></returns>
        public IActionResult Detail(int id = 0)
        {
            if (id > 0)
            {
                var editModel = _context.ManagerDll.GetModel(id);
                ViewData["editModel"] = editModel ?? throw new Exception("未找到匹配的管理员信息");
            }
            //获取角色组
            var baseRoleList = _roledb.GetRoleList();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in baseRoleList)
            {
                selectListItems.Add(new SelectListItem { Text = item.SystemManagerRoleName, Value = item.SystemManagerRoleId.ToString() });
            }
            ViewData["baseRoleList"] = selectListItems;
            return View();
        }
        #endregion
    }
}