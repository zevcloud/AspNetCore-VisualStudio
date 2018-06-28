using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context.Config;
using AspNetCore.Mvc.Context.IDb;
using AspNetCore.Mvc.Utils.Enum;
using AspNetCore.Mvc.Utils.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCore.Mvc.Entities;
namespace AspNetCore.Mvc.Web.Controllers
{
    public class NavController : Controller
    {
        public INavigationDb _nav;

        public SqlSugarFactoryContext _context;
        public NavController(INavigationDb nav, SqlSugarFactoryContext context)
        {
            _context = context;
            _nav = nav;
        }

        public IActionResult Index()
        {
            var navList = _nav.GetNavigationAllList();
            var dylist = new List<dynamic>();
            foreach (var item in navList)
            {
                var id = item.NavId;
                var bieming = item.NavIdent;
                var title = item.NavParentId == 0 ? item.NavTitle : " ├ " + item.NavTitle;
                var link = item.NavURL;
                var status = ((EnumStatus.Status)Enum.Parse(typeof(EnumStatus.Status), item.NavisLock.ToString())).GetDisplayName();
                var sort = item.NavSort;
                var isSys = item.NavIsSys;
                dylist.Add(new { id, bieming, title, link, status, sort, isSys });
            }
            var jsonText = JsonUnits.ConvertJsonString(JsonUnits.ToJSON(dylist));
            ViewData["navData"] = jsonText;
            return View();
        }


        /// <summary>
        /// 导航详情页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addid">添加子级的ID</param>
        /// <returns></returns>
        public IActionResult Detail(int id = 0, int addid = 0)
        {
            var editModel = new NavigationModel();
            var selectedId = 0;
            if (id > 0)
            {
                editModel = _nav.GetModel(id);
                selectedId = editModel == null ? 0 : editModel.NavParentId;
                ViewData["editModel"] = editModel ?? throw new Exception("未找到匹配的导航信息");
            }
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            //获取到父级导航信息
            var fatherList = _nav.GetNavUpperLevel();
            selectListItems.Add(new SelectListItem() { Text = "==顶级分类==", Value = "0" });
            foreach (var item in fatherList)
            {

                if (item.NavId == selectedId)
                {
                    selectListItems.Add(new SelectListItem() { Text = item.NavTitle, Value = item.NavId.ToString(), Selected = true });
                }

                else
                {
                    selectListItems.Add(new SelectListItem() { Text = item.NavTitle, Value = item.NavId.ToString() });
                }
            }
            ViewData["baseNavItems"] = selectListItems;
            return View();
        }
    }
}