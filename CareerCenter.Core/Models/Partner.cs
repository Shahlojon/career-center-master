using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Partner:Base
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Logo { get; set; }

        public string Description { get; set; }
        //...... 

        public virtual PartnerCategory PartnerCategory { get; set; }
    }
}
