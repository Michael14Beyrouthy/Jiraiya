﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jiraiya.Models
{
    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool Closed { get; set; }

        [Required]
        public Sprint Sprint { get; set; }
    }
}