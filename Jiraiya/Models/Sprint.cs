using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jiraiya.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime PredictedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public Project Project { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int ProjectId { get; set; }


    }
}