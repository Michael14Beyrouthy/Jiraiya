using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiraiya.Models;

namespace Jiraiya.Controllers
{
    public class ProjectUsersController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectUsersController()
        {
            _context = new ApplicationDbContext();
        }

        /*_context is a disposable object so we need to properly dispose it
        the proper way of doing so is by overriding the dispose method */
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: ProjectUsers
        public ActionResult New(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            return View(project);
        }
    }
}