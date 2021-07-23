using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Jiraiya.Dtos;
using Jiraiya.Models;
using Microsoft.AspNet.Identity;

namespace Jiraiya.Controllers.Api
{
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/projects
        public IHttpActionResult GetProjects(int applicationUserId = 0)
        {
            var projectUsers = _context.ProjectUsers.Where(p => p.ApplicationUserId == applicationUserId);

            List<int> projectIds = new List<int>();

            foreach (var projectUser in projectUsers)
                projectIds.Add(projectUser.ProjectId);

            var projectsQuery = _context.Projects.Include(p => p.Sprints).Where(p => projectIds.Contains(p.Id));

            var projectDtos = projectsQuery.ToList().Select(Mapper.Map<Project, ProjectDto>);

            return Ok(projectDtos);
        }

        //GET /api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.Include(p => p.Sprints).SingleOrDefault(p => p.Id == id);

            if (project == null)
                return NotFound();

            return Ok(Mapper.Map<Project, ProjectDto>(project));
        }

        //POST /api/projects
        [HttpPost]
        public IHttpActionResult CreateProject(ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var project = Mapper.Map<ProjectDto, Project>(projectDto);

            _context.Projects.Add(project);
            _context.SaveChanges();

            /*
             * COPYING CREATE PROJECTUSER CODE FROM POJECTUSERSCONTROLLER IN ORDER
             * TO CREATE A NEW PROJECT USER BETWEEN THE NEWLY CREATED PROJECT AND ITS CREATOR. 
             * THERE IS MAYBE A BETTER WAY TO DO THIS.
             */

            int currentUserId = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            ProjectUserDto projectUser = new ProjectUserDto()
            {
                ApplicationUserId = currentUserId,
                ProjectId = project.Id
            };

            var applicationUserForProjectUser = _context.Users.Single(u => u.Id == projectUser.ApplicationUserId);
            var projectForProjectUser = _context.Projects.Single(p => p.Id == projectUser.ProjectId);

            var newProjectUser = new ProjectUser()
            {
                ApplicationUser = applicationUserForProjectUser,
                Project = projectForProjectUser
            };

            _context.ProjectUsers.Add(newProjectUser);
            _context.SaveChanges();

            projectDto.Id = project.Id;

            return Created(new Uri(Request.RequestUri + "/" + project.Id), projectDto);
        }

        //PUT /api/projects/1
        [HttpPut]
        public void UpdateProject(int id, ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(projectDto, projectInDb);

            _context.SaveChanges();
        }

        //DELETE /api/projects/1
        [HttpDelete]
        public void DeleteProject(int id)
        {

            var projectInDb = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (projectInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();
        }

    }
}
