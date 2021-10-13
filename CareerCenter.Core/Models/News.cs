﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class News: Base
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Viewed { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
