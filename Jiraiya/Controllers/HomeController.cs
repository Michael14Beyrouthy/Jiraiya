using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiraiya.Models;
using Microsoft.AspNet.Identity;

namespace Jiraiya.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        /*_context is a disposable object so we need to properly dispose it
        the proper way of doing so is by overriding the dispose method */
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            /*int applicationUserId = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var projectUsers = _context.ProjectUsers.Where(p => p.ApplicationUserId == applicationUserId);

            List<int> projectIds = new List<int>();

            foreach (var projectUser in projectUsers)
                projectIds.Add(projectUser.ProjectId);

            var projects = _context.Projects.Include(p => p.Sprints).Where(p => projectIds.Contains(p.Id)).ToList();

            List<Sprint> sprints = new List<Sprint>();

            foreach (var project in projects)
            {
                var sprint = _context.Sprints.Include(s => s.Issues).SingleOrDefault(s => s.Id == project.Id);

            }*/

            
            return View();
        }
    }
}