using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Mvc.Context;
using AspNetCore.Mvc.Context.Config;
using AspNetCore.Mvc.Context.IDb;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.Web.Controllers
{
    public class LayoutController : Controller
    {
        public INavigationDb _context;
        public LayoutController(INavigationDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Left()
        {
            var allList = _context.GetNavList();
            ViewData["list"] = allList;
            return View();
        }
    }
}