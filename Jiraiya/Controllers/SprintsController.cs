using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiraiya.Models;

namespace Jiraiya.Controllers
{
    public class SprintsController : Controller
    {
        private ApplicationDbContext _context;

        public SprintsController()
        {
            _context = new ApplicationDbContext();
        }

        /*_context is a disposable object so we need to properly dispose it
        the proper way of doing so is by overriding the dispose method */
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Sprints
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(int? id)
        {
            return View("SprintsForm", id);
        }

        public ActionResult ViewSprint(int id)
        {
            var sprint = _context.Sprints.SingleOrDefault(s => s.Id == id);

            if (sprint == null)
                return HttpNotFound();

            return View("SprintPage", sprint);
        }

        public ActionResult ChangeStatus(int id, bool open)
        {
            var sprint = _context.Sprints.SingleOrDefault(i => i.Id == id);

            var allSprints = _context.Sprints.Where(s => s.ProjectId == sprint.ProjectId).ToList();

            if (sprint != null)
            {
                if (open)
                {
                    foreach (var curr in allSprints)
                    {
                        if (curr.Open)
                            return View("CantOpenSprint", sprint);
                    }

                    sprint.Open = true;
                    _context.SaveChanges();
                    return View("SprintPage", sprint);
                }
                    
                else
                    sprint.Open = false;
            }

            _context.SaveChanges();

            return View("SprintPage", sprint);
        }
    }
}