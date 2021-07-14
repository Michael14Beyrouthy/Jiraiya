using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jiraiya.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime PredictedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public List<Sprint> Sprints { get; set; }

    }
}