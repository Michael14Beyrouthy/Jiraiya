using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jiraiya.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime PredictedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public ICollection<Sprint> Sprints { get; set; }

    }
}