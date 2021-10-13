using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class NotableStudent:Base
    {
        [Required]
        public string Title { get; set; }

        public  int UniversityId { get; set; }

        public string Image { get; set; }

        [Required]
        public string Content { get; set; }
        public virtual University University { get; set; }
    }
}
