using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Jiraiya.Dtos;
using Jiraiya.Models;

namespace Jiraiya.Controllers.Api
{
    public class ProjectUsersController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectUsersController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult CreateProjectUser(ProjectUserDto projectUser)
        {
            var applicationUser = _context.Users.Single(u => u.Id == projectUser.ApplicationUserId);
            var project = _context.Projects.Single(p => p.Id == projectUser.ProjectId);

            var newProjectUser = new ProjectUser()
            {
                ApplicationUser = applicationUser,
                Project = project
            };
            
            _context.ProjectUsers.Add(newProjectUser);
            _context.SaveChanges();

            return Ok();
        }
    }
}
