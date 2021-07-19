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

namespace Jiraiya.Controllers.Api
{
    public class SprintsController : ApiController
    {
        private ApplicationDbContext _context;

        public SprintsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/sprints
        public IHttpActionResult GetSprints()
        {
            return Ok(_context.Sprints.ToList().Select(Mapper.Map<Sprint, SprintDto>));
        }

        //GET /api/sprints/1
        public IHttpActionResult GetSprint(int id)
        {
            var sprint = _context.Sprints.SingleOrDefault(s => s.Id == id);

            if (sprint == null)
                return NotFound();

            return Ok(Mapper.Map<Sprint, SprintDto>(sprint));
        }

        //POST /api/sprints
        [HttpPost]
        public IHttpActionResult CreateSprint(SprintDto sprintDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sprint = Mapper.Map<SprintDto, Sprint>(sprintDto);

            _context.Sprints.Add(sprint);
            _context.SaveChanges();

            sprintDto.Id = sprint.Id;

            return Created(new Uri(Request.RequestUri + "/" + sprint.Id), sprintDto);
        }

        //PUT /api/sprints/1
        [HttpPut]
        public void UpdateSprint(int id, SprintDto sprintDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var sprintInDb = _context.Sprints.SingleOrDefault(s => s.Id == id);

            if (sprintInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(sprintDto, sprintInDb);

            _context.SaveChanges();
        }

        //DELETE /api/sprints/1
        [HttpDelete]
        public void DeleteSprint(int id)
        {

            var sprintInDb = _context.Sprints.SingleOrDefault(s => s.Id == id);

            if (sprintInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Sprints.Remove(sprintInDb);
            _context.SaveChanges();
        }
    }
}
