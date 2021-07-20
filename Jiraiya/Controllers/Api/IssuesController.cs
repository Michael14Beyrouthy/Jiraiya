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
    public class IssuesController : ApiController
    {
        private ApplicationDbContext _context;

        public IssuesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/issues
        public IHttpActionResult GetIssues(int sprintId = 0)
        {
            if (sprintId != 0)
                return Ok(_context.Issues.Where(i => i.SprintId == sprintId).ToList().Select(Mapper.Map<Issue, IssueDto>));

            return Ok(_context.Issues.ToList().Select(Mapper.Map<Issue, IssueDto>));
        }

        //GET /api/issues/1
        public IHttpActionResult GetIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(s => s.Id == id);

            if (issue == null)
                return NotFound();

            return Ok(Mapper.Map<Issue, IssueDto>(issue));
        }

        //POST /api/issues
        [HttpPost]
        public IHttpActionResult CreateIssue(IssueDto issueDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var issue = Mapper.Map<IssueDto, Issue>(issueDto);

            _context.Issues.Add(issue);
            _context.SaveChanges();

            issueDto.Id = issue.Id;

            return Created(new Uri(Request.RequestUri + "/" + issue.Id), issueDto);
        }

        //PUT /api/issues/1
        [HttpPut]
        public void UpdateIssue(int id, IssueDto issueDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var issueInDb = _context.Issues.SingleOrDefault(s => s.Id == id);

            if (issueInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(issueDto, issueInDb);

            _context.SaveChanges();
        }

        //DELETE /api/issues/1
        [HttpDelete]
        public void DeleteIssue(int id)
        {

            var issueInDb = _context.Issues.SingleOrDefault(s => s.Id == id);

            if (issueInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Issues.Remove(issueInDb);
            _context.SaveChanges();
        }
    }
}
