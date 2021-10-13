using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Faq:Base
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual FaqCategory FaqCategory { get; set; }
    }
}
