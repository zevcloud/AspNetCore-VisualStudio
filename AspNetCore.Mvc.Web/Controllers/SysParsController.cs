﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Mvc.Web.Controllers
{
    public class SysParsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}