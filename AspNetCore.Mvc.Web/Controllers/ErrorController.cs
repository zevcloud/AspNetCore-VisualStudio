using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.Web.Controllers
{
    public class ErrorController : Controller
    {


        public IActionResult Index(int statusCode)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error.Message;
            ViewData["error"] = error;
            return View();
        }
    }
}