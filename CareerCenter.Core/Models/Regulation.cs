using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Regulation:Base
    {
        [Required]
        public string Title { get; set; }

        public string File { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public virtual RegulationCategory RegulationCategory { get; set; }
    }
}
