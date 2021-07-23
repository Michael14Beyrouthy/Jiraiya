using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Jiraiya.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Jiraiya.Controllers
{
    public class IssuesController : Controller
    {
        private ApplicationDbContext _context;

        public IssuesController()
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


        public ActionResult New(int? id)
        {
            return View("IssuesForm", id);
        }

        public ActionResult ViewIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(i => i.Id == id);

            if (issue == null)
                return HttpNotFound();

            return View("IssuePage", issue);
        }

        public ActionResult ChangeStatus(int id, bool close)
        {
            var issue = _context.Issues.SingleOrDefault(i => i.Id == id);

            if (issue != null)
            {
                if (close) 
                    issue.Closed = true;
                else
                    issue.Closed = false;
            }

            _context.SaveChanges();

            return View("IssuePage", issue);
        }
    }
}