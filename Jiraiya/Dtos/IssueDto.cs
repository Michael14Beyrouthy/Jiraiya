using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Jiraiya.Models;

namespace Jiraiya.Dtos
{
    public class IssueDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Closed { get; set; }
        public SprintDto Sprint { get; set; }
    }
}