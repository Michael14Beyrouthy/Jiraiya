using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiraiya.Models;

namespace Jiraiya.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        /*_context is a disposable object so we need to properly dispose it
        the proper way of doing so is by overriding the dispose method */
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
                return HttpNotFound();

            return View("ProjectPage", project);
        }

        public ActionResult NewSprint(int id)
        {
            return View("NewSprint", id);
        }
    }
}