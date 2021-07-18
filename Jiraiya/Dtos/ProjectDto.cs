using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Jiraiya.Models;

namespace Jiraiya.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        public DateTime? StartDate { get; set; }

        //[Required]
        public DateTime? PredictedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        //[Required]
        public ICollection<SprintDto> Sprints { get; set; }
    }
}