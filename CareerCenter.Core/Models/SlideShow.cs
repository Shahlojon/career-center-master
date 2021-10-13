using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class SlideShow:Base
    {
        [Required]
        public string Location { get; set; }

        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

    }
}
