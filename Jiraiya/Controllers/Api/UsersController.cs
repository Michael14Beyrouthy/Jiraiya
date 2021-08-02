using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Jiraiya.Models;
using Microsoft.AspNet.Identity;

namespace Jiraiya.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/users
        public IHttpActionResult GetUsers(string query = null)
        {
            var usersOriginalQuery = _context.Users.ToList();

            IEnumerable<ApplicationUser> usersQuery = _context.Users.ToList();

            if (!String.IsNullOrWhiteSpace(query))
                usersQuery = usersOriginalQuery.Where(c => c.Email.Contains(query)).ToList();

            return Ok(usersQuery);
        }
    }
}
