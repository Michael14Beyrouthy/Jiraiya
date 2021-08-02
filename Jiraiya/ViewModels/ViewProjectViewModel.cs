using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jiraiya.Models;

namespace Jiraiya.ViewModels
{
    public class ViewProjectViewModel
    {
        public Project Project { get; set; }

        public Sprint OpenSprint { get; set; }

        public int OpenSprintId { get; set; }
    }
}