﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; } 
        public int CustomerId { get; set; }
    }
}