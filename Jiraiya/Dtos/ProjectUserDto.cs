using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jiraiya.Dtos
{
    public class ProjectUserDto
    {
        public int ApplicationUserId { get; set; }

        public int ProjectId { get; set; }
    }
}