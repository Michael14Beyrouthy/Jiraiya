﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jiraiya.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}