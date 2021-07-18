using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Jiraiya.Dtos;
using Jiraiya.Models;

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
        public IEnumerable<ProjectDto> GetProjects()
        {
            return _context.Projects.ToList().Select(Mapper.Map<Project, ProjectDto>);
        }

        //GET /api/projects/1
        public IHttpActionResult GetProject(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

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
