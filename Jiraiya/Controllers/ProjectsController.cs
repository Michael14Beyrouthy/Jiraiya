using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jiraiya.Models;
using Jiraiya.ViewModels;

namespace Jiraiya.Controllers
{
    [Authorize]
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(int? id)
        {
            return View("ProjectsForm", id);
        }

        public ActionResult ViewProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            var viewModel = new ViewProjectViewModel();
            viewModel.Project = project;

            if (project == null)
                return HttpNotFound();

            var projectSprints = _context.Sprints /*.Include(s => s.Issues)*/.Where(s => s.ProjectId == project.Id)
                .ToList();

            foreach (var sprint in projectSprints)
                if (sprint.Open)
                {
                    viewModel.OpenSprint = sprint;
                    viewModel.OpenSprintId = sprint.Id;
                    return View("ProjectPage", viewModel);
                }

            viewModel.OpenSprint = null;
            viewModel.OpenSprintId = 0;

            return View("ProjectPage", viewModel);
        }
    }
}