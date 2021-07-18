using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Jiraiya.Models;

namespace Jiraiya.Dtos
{
    public class SprintDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime PredictedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public ProjectDto Project { get; set; }
        public byte ProjectId { get; set; }
        public List<IssueDto> Issues { get; set; }

    }
}