using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jiraiya.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Closed { get; set; }
        public Sprint Sprint { get; set; }
    }
}